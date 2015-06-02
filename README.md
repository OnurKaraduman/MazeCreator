Maze Create With Backtracker Algorithm
First we need to figure out how algorithm working.  You can take a look this link:https://www.youtube.com/watch?v=elMXlO28Q1U
I thought this project on paper. I jut drawed what i will have as object. Because we’re gonna approach  to project with logic of Object Oriented Programming. So, we need to infrence object which will locate . 
Now, we need a Scene named Board in project. This algorithm needs squares then it goes on each square side by stressing line. Therefore, we need squares on board named BoardSquare.

                                    ----------------
                                      |MainWindow |
                                     ----------------
                                            | 
                                        /      \
                                        -----------
                                          |Board|
                                        -----------
                                             |
                                      -------------------
                                        |BoardSquare|
                                       -------------------

Board has 2 main method:
Create:  initialize the scene, finding squares.
MazeCreator: This is recursive function to create random maze. It just draws line on square edge. 

