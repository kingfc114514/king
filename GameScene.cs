using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Xml.Linq;


namespace 飞机大战
{
    class GameScene : ISceneUpdate
    {
        Map map;
        Myplane myplane;
        Random random;
        Enemyplane[] enemyplanes;
        BossPlane bossplane;
        int score;
        int Level;
        int Reward;
        int BulletNum;
        public GameScene()
        {
            map = new Map();
            myplane = new Myplane(new Position(30,40));
            random = new Random();
            enemyplanes = new Enemyplane[5];
            score = 0;
            Reward = 0;
            Level = 1;
            BulletNum = 30;
            HeipPlayer();
        }
        int turn = 1;
        public void HeipPlayer()
        { 
            ConsoleColor color = ConsoleColor.Yellow;
            Console.SetCursorPosition(62, 10);
            Console.WriteLine("上下左右移动：wsad");
            Console.SetCursorPosition(62, 11);
            Console.WriteLine("攻击：j");
            Console.SetCursorPosition(62, 12);
            Console.WriteLine("升级：1      2");
        }
        public void Update()
        {
            map.Draw(myplane.hp,myplane.atk,score,Level,Reward,BulletNum);
            myplane.Draw();
            if(turn % 1200 == 0)
            {
                bool enemyexist = false;
                for (int i = 0; i < enemyplanes.Length; i++)
                {
                    if (enemyplanes[i] != null)
                    {
                        enemyexist=true;
                        break;
                    }
                }
                if (!enemyexist&&bossplane==null)
                {
                    Position enemypos = new Position(random.Next(14, 46), random.Next(3, 8));
                    bossplane = new BossPlane(enemypos, Level);
                    bossplane.Draw();
                }
                else
                {
                    turn -= 399;
                }
            }
            if (turn % 400 == 0&&bossplane==null)
            {
                Position enemypos=new Position(random.Next(14,46), random.Next(3,8));
                for(int i = 0; i < enemyplanes.Length; i++)
                {
                    if (enemyplanes[i] == null)
                    {
                        enemyplanes[i] = new Enemyplane(enemypos,Level);
                        enemyplanes[i].Draw();
                        break;
                    }
                }
            }
            if (turn % 200 == 0)
            {
                for (int i = 0; i < enemyplanes.Length; i++)
                {
                    if (enemyplanes[i] != null)
                    {
                        enemyplanes[i].Attack();
                    }
                }
            }
            if (turn % 100 == 0)
            {
                
                    if (bossplane != null)
                    {
                        bossplane.Attack();
                    }

            }
            if (turn % 20 == 0)
            {
                for (int i = 0; i < enemyplanes.Length; i++)
                {
                    if (enemyplanes[i] != null)
                    {
                        for (int j = 0; j < enemyplanes[i].bullets.Length; j++)
                        {
                            if (enemyplanes[i].bullets[j] != null)
                            {
                                enemyplanes[i].bullets[j].Move();
                                if (enemyplanes[i].bullets[j].Hit(myplane))
                                { 
                                    myplane.hp= myplane.hp - enemyplanes[i].bullets[j].atk;
                                    if(myplane.hp <= 0)
                                    {
                                        Game.ChangeScene(E_SceneType.End,score);
                                    }
                                    Console.SetCursorPosition(enemyplanes[i].bullets[j].pos.x, enemyplanes[i].bullets[j].pos.y);
                                    Console.Write(' ');
                                    enemyplanes[i].bullets[j] = null;
                                    continue;
                                }
                                enemyplanes[i].bullets[j].Move();
                                if (enemyplanes[i].bullets[j].Hit(myplane))
                                {
                                    myplane.hp = myplane.hp - enemyplanes[i].bullets[j].atk;
                                    if (myplane.hp <= 0)
                                    {
                                        Game.ChangeScene(E_SceneType.End,score);
                                    }
                                    Console.SetCursorPosition(enemyplanes[i].bullets[j].pos.x, enemyplanes[i].bullets[j].pos.y);
                                    Console.Write(' ');
                                    enemyplanes[i].bullets[j] = null;
                                    continue;
                                }
                                if (enemyplanes[i].bullets[j].pos.y >= Game.h - 6)
                                {
                                    Console.SetCursorPosition(enemyplanes[i].bullets[j].pos.x, enemyplanes[i].bullets[j].pos.y);
                                    Console.Write(' ');
                                    enemyplanes[i].bullets[j] = null;
                                }
                            }
                        }
                    }
                }
                if(bossplane != null)
                {
                    for (int i = 0; i < bossplane.bullets.Length; i++)
                    {
                        if(bossplane.bullets[i] != null)
                        {
                            bossplane.bullets[i].Move();
                            if (bossplane.bullets[i].Hit(myplane))
                            {
                                myplane.hp = myplane.hp - bossplane.bullets[i].atk;
                                if (myplane.hp <= 0)
                                {
                                    Game.ChangeScene(E_SceneType.End, score);
                                }
                                Console.SetCursorPosition(bossplane.bullets[i].pos.x, bossplane.bullets[i].pos.y);
                                Console.Write(' ');
                                bossplane.bullets[i] = null;
                                continue;
                            }
                            bossplane.bullets[i].Move();
                            if (bossplane.bullets[i].Hit(myplane))
                            {
                                myplane.hp = myplane.hp - bossplane.bullets[i].atk;
                                if (myplane.hp <= 0)
                                {
                                    Game.ChangeScene(E_SceneType.End, score);
                                }
                                Console.SetCursorPosition(bossplane.bullets[i].pos.x, bossplane.bullets[i].pos.y);
                                Console.Write(' ');
                                bossplane.bullets[i] = null;
                                continue;
                            }
                            if (bossplane.bullets[i].pos.y >= Game.h - 6)
                            {
                                Console.SetCursorPosition(bossplane.bullets[i].pos.x, bossplane.bullets[i].pos.y);
                                Console.Write(' ');
                                bossplane.bullets[i] = null;
                            }
                        }
                    }
                }
            }
            if (turn % 40 == 0)
            {
                for(int i = 0; i < enemyplanes.Length; i++)
                {
                    if(enemyplanes[i] != null)
                    {
                        enemyplanes[i].Move();
                        if(enemyplanes[i].pos.y >= Game.h-4)
                        {
                            enemyplanes[i] = null;
                            continue;
                        }
                        enemyplanes[i].Draw();
                    }
                }
                if(bossplane != null)
                {
                    bossplane.Move();
                    bossplane.Draw();
                }
            }
            if (turn % 10 == 0)
            {
                for(int i = 0; i < enemyplanes.Length; i++)
                {
                    if(enemyplanes[i] != null)
                    {
                        enemyplanes[i].Draw();
                    }
                }
                if(bossplane != null)
                {
                    bossplane.Draw();
                }
                if (myplane.bullets.Length > 0)
                {
                    if(bossplane == null)
                    {
                        for (int i = 0; i < myplane.bullets.Length; i++)
                        {
                            if (myplane.bullets[i] != null)
                            {
                                myplane.bullets[i].Move();
                                bool flag = true;
                                if (enemyplanes.Length > 0)
                                {
                                    for (int j = 0; j < enemyplanes.Length; j++)
                                    {

                                        if (enemyplanes[j] != null && myplane.bullets[i].Hit(enemyplanes[j]))
                                        {
                                            enemyplanes[j].hp -= myplane.bullets[i].atk;
                                            Console.SetCursorPosition(myplane.bullets[i].pos.x, myplane.bullets[i].pos.y);
                                            Console.Write(' ');
                                            flag = false;
                                            BulletNum++;
                                            myplane.bullets[i] = null;
                                            if (enemyplanes[j].hp <= 0)
                                            {
                                                score += 10*Level;
                                                for (int k = 0; k < enemyplanes[j].planes.Length; k++)
                                                {
                                                    Console.SetCursorPosition(enemyplanes[j].planes[k].pos.x, enemyplanes[j].planes[k].pos.y);
                                                    Console.Write(" ");
                                                }
                                                for (int k = 0; k < enemyplanes[j].bullets.Length; k++)
                                                {
                                                    if (enemyplanes[j].bullets[k] != null)
                                                    {
                                                        Console.SetCursorPosition(enemyplanes[j].bullets[k].pos.x, enemyplanes[j].bullets[k].pos.y);
                                                        Console.Write(' ');
                                                    }
                                                }
                                                enemyplanes[j] = null;
                                            }
                                            break;
                                        }
                                    }
                                    if (flag)
                                    {
                                        if (myplane.bullets[i].pos.y <= 2)
                                        {
                                            Console.SetCursorPosition(myplane.bullets[i].pos.x, myplane.bullets[i].pos.y);
                                            Console.Write(' ');
                                            BulletNum++;
                                            myplane.bullets[i] = null;
                                        }
                                    }
                                }

                            }
                        }
                    }
                    else if(bossplane != null)
                    {
                        for(int i = 0; i < myplane.bullets.Length; i++)
                        {
                            if(myplane.bullets[i] != null)
                            {
                                myplane.bullets[i].Move();
                                if (myplane.bullets[i].Hit(bossplane))
                                {
                                    bossplane.hp -= myplane.bullets[i].atk;
                                    Console.SetCursorPosition(myplane.bullets[i].pos.x, myplane.bullets[i].pos.y);
                                    Console.Write(' ');
                                    BulletNum++;
                                    myplane.bullets[i] = null;
                                    if (bossplane.hp <= 0)
                                    {
                                        score += 50*Level;
                                        for (int k = 0; k < bossplane.planes.Length; k++)
                                        {
                                            Console.SetCursorPosition(bossplane.planes[k].pos.x, bossplane.planes[k].pos.y);
                                            Console.Write(" ");
                                        }
                                        for (int k = 0; k < bossplane.bullets.Length; k++)
                                        {
                                            if (bossplane.bullets[k] != null)
                                            {
                                                Console.SetCursorPosition(bossplane.bullets[k].pos.x, bossplane.bullets[k].pos.y);
                                                Console.Write(' ');
                                            }
                                        }
                                        bossplane = null;
                                        Reward += Level;
                                        Level++;
                                        turn = 1;
                                    }
                                    break;
                                }
                                if (myplane.bullets[i].pos.y <= 2)
                                {
                                    Console.SetCursorPosition(myplane.bullets[i].pos.x, myplane.bullets[i].pos.y);
                                    Console.Write(' ');
                                    BulletNum ++;
                                    myplane.bullets[i] = null;
                                }
                            }
                            
                        }

                    }
                    
                }
            }
            turn++;
            
            if (Console.KeyAvailable)
            {
                //检测输入输出 不能再 间隔帧里面去处理 应该每次都检测 这样才准确
                char Moveboard=Console.ReadKey(true).KeyChar;
                if(Moveboard == 'a' || Moveboard == 'A'|| Moveboard == 'd' || Moveboard == 'D'|| Moveboard == 'w' || Moveboard == 'W'|| Moveboard == 's' || Moveboard == 'S'){
                    myplane.Move(Moveboard);
                }
                if (Moveboard == 'j' || Moveboard == 'J')
                {
                    myplane.attack();
                    if(BulletNum > 0)
                    {
                        BulletNum--;
                    }
                }
                if(Moveboard == '1')
                {
                    Reward = myplane.ATKup(Reward);
                }
                if(Moveboard == '2')
                {
                    Reward = myplane.HPup(Reward,Level);
                }
            }
        }
    }
}
