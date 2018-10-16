using UnityEngine;
using System;
using System.Collections.Generic;       //Allows us to use Lists.
using Random = UnityEngine.Random;      //Tells Random to use the Unity Engine random number generator.
//using UnityEngine.UI;
using UnityEngine.SceneManagement;
    
    public class BoardManager : MonoBehaviour
    {
        // Using Serializable allows us to embed a class with sub properties in the inspector.
        [Serializable]
        public class Count {
            public int minimum;             //Minimum value for our Count class.
            public int maximum;             //Maximum value for our Count class.
        
            
            //Assignment constructor.
            public Count (int min, int max)
            {
                minimum = min;
                maximum = max;
            }
        }
        
        private int columns = 20;                                       //Number of columns in our game board.
        private int rows = 10;                                          //Number of rows in our game board.
        public GameObject[] floorTiles;                                 //Array of floor prefabs.
        private int floorIndexBegin;
        private int floorIndexEnd;
        public GameObject exit;
        private int currentScene;
        
        private Transform boardHolder;                                  //A variable to store a reference to the transform of our Board object.
        private List <Vector3> gridPositions = new List <Vector3> ();   //A list of possible locations to place tiles.
        
        //Clears our list gridPositions and prepares it to generate a new board.
        void InitialiseList () {
            //Clear our list gridPositions.
            gridPositions.Clear ();
            
            //Loop through x axis (columns).
            for(int x = 1; x < columns-1; x++) {
                //Within each column, loop through y axis (rows).
                for(int y = 1; y < rows-1; y++) {
                    //At each index add a new Vector3 to our list with the x and y coordinates of that position.
                    gridPositions.Add (new Vector3(x, y, 0f));
                }
            }
        }
        
        
        //Sets up the outer walls and floor (background) of the game board.
        void BoardSetup () {
            //Instantiate Board and set boardHolder to its transform.
            boardHolder = new GameObject ("Board").transform;
            currentScene = SceneManager.GetActiveScene().buildIndex;
            //vv where in the array do you select the floor sprites vv//
            if (currentScene == 0) {
                floorIndexBegin = 0;
                floorIndexEnd = 14;
            }
            else if (currentScene == 1) {
                floorIndexBegin = 15;
                floorIndexEnd = 25;
            }
            else if (currentScene == 2) {
                floorIndexBegin = 26;
                floorIndexEnd = 30;
            }
            else if (currentScene == 3) {
                floorIndexBegin = 31;
                floorIndexEnd = 40;
            }
            else if (currentScene == 4) {
                floorIndexBegin = 41;
                floorIndexEnd = 45;
            }
            else if (currentScene == 5) {
                floorIndexBegin = 46;
                floorIndexEnd = 66;
            }
            else if (currentScene == 6) {
                floorIndexBegin = 41;
                floorIndexEnd = 66;
            }
            else if (currentScene == 7) {
                floorIndexBegin = 15;
                floorIndexEnd = 30;
            }
            else if (currentScene == 8) {
                floorIndexBegin = 31;
                floorIndexEnd = 45;
            }
            int floorCounter = 0;
            //Loop along x axis, starting from -1 (to fill corner) with floor or outerwall edge tiles.
            for(int x = -1; x < columns + 1; x++) {
                //Loop along y axis, starting from -1 to place floor or outerwall tiles.
                for(int y = -1; y < rows + 1; y++) {
                    //Choose a random tile from our array of floor tile prefabs and prepare to instantiate it.
                    //GameObject toInstantiate = floorTiles[Random.Range (0,floorTiles.Length)];
                    GameObject toInstantiate = floorTiles[Random.Range(floorIndexBegin, floorIndexEnd)];

                    //Instantiate the GameObject instance using the prefab chosen for toInstantiate at the Vector3 corresponding to current grid position in loop, cast it to GameObject.
                    GameObject instance =
                        Instantiate (toInstantiate, new Vector3 (x, y, 0f), Quaternion.identity) as GameObject;
                    var sprRenderer = instance.GetComponent<SpriteRenderer>();
                    sprRenderer.sortingOrder = floorCounter++;
                    
                    //Set the parent of our newly instantiated object instance to boardHolder, this is just organizational to avoid cluttering hierarchy.
                    instance.transform.SetParent (boardHolder);
                }
            }
        }
        
        
        //RandomPosition returns a random position from our list gridPositions.
        Vector3 RandomPosition () {
            //Declare an integer randomIndex, set it's value to a random number between 0 and the count of items in our List gridPositions.
            int randomIndex = Random.Range (0, gridPositions.Count);
            
            //Declare a variable of type Vector3 called randomPosition, set it's value to the entry at randomIndex from our List gridPositions.
            Vector3 randomPosition = gridPositions[randomIndex];
            
            //Remove the entry at randomIndex from the list so that it can't be re-used.
            gridPositions.RemoveAt (randomIndex);
            
            //Return the randomly selected Vector3 position.
            return randomPosition;
        }
        
        
        //SetupScene initializes our level and calls the previous functions to lay out the game board
        public void SetupScene () {
            //Creates the outer walls and floor.
            BoardSetup ();
            
            //Reset our list of gridpositions.
            InitialiseList ();

            Instantiate (exit, new Vector3 (columns, rows, 0f), Quaternion.identity);
            //Debug.Log(currentScene);
        }
    }




