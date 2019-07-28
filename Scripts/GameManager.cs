using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject squarePrefab;
    Cell[,] cells;
    float timer;
    float waitTime;
    public bool isPaused, isEditable;
    public Color colorAlive, colorDead;

    struct Cell
    {
        public bool IsAlive;
        public bool NextState;
        public GameObject square;
    }

    string presetPulsar =    "..............." +
                             "...OOO...OOO..." +
                             "..............." +
                             ".O....O.O....O." +
                             ".O....O.O....O." +
                             ".O....O.O....O." +
                             "...OOO...OOO..." +
                             "..............." +
                             "...OOO...OOO..." +
                             ".O....O.O....O." +
                             ".O....O.O....O." +
                             ".O....O.O....O." +
                             "..............." +
                             "...OOO...OOO..." +
                             "...............";
    string presetPentadecathlon =   "................" +
                                    "................" +
                                    "................" +
                                    ".....O....O....." +
                                    "...OO.OOOO.OO..." +
                                    ".....O....O....." +
                                    "................" +
                                    "................" +
                                    "................";
    string presetGliderGun =    "........................O..........." +
                                "......................O.O..........." +
                                "............OO......OO............OO" +
                                "...........O...O....OO............OO" +
                                "OO........O.....O...OO.............." +
                                "OO........O...O.OO....O.O..........." +
                                "..........O.....O.......O..........." +
                                "...........O...O...................." +
                                "............OO......................";

    string presetBrain =    ".OOO.........OOO."+
                            "O.O.OO.....OO.O.O"+
                            "O.O.O.......O.O.O"+
                            ".O.OO.OO.OO.OO.O."+
                            ".....O.O.O.O....."+
                            "...O.O.O.O.O.O..."+
                            "..OO.O.O.O.O.OO.."+
                            "..OOO..O.O..OOO.."+
                            "..OO..O...O..OO.."+
                            ".O....OO.OO....O."+
                            ".O.............O.";

    string presetFountain =     ".........O........."+
                                "..................."+
                                "...OO.O.....O.OO..."+
                                "...O.....O.....O..."+
                                "....OO.OO.OO.OO...."+
                                "..................."+
                                "......OO...OO......"+
                                "OO...............OO"+
                                "O..O...O.O.O...O..O"+
                                ".OOO.OOOOOOOOO.OOO."+
                                "....O....O....O...."+
                                "...OO.........OO..."+
                                "...O...........O..."+
                                ".....O.......O....."+
                                "....OO.......OO....";

    string presetFox =  "....O..."+
                        "....O..."+
                        "..O..O.."+
                        "OO......"+
                        "....O.O."+
                        "..O.O.O."+
                        "......O.";

    string presetGerm =     "....OO...."+
                            ".....O...."+
                            "...O......"+
                            "..O.OOOO.."+
                            "..O....O.."+
                            ".OO.O....."+
                            "..O.O.OOOO"+
                            "O.O.O....O"+
                            "OO...OOO.."+
                            ".......OO.";

    string presetSmiley =   "......."+
                            "OOO.OOO"+
                            ".O.O.O."+
                            "......."+
                            ".O...O."+
                            "......."+
                            "O.O.O.O"+
                            "..O.O..";


    private void Start()
    {
        waitTime = 10 / StaticPass.Speed;
        isPaused = false;
        isEditable = false;
        cells = new Cell[StaticPass.SizeX, StaticPass.SizeY];
        for (int i = 0; i < StaticPass.SizeX; i++)
        {
            for (int j = 0; j < StaticPass.SizeY; j++)
            {
                cells[i, j] = new Cell
                {
                    NextState = false,
                    square = Instantiate(squarePrefab, new Vector3(i, j), Quaternion.identity)
                };
                SetAlive(i, j, false);
            }
        }
        ApplyPreset();
    }

    void ApplyPreset()
    {
        int k = 0;
        switch(StaticPass.Preset)
        {
            case 1:
                
                //welcomeText.text += "Blank";
            break;
            case 2:
                for(int i = StaticPass.SizeY - 1; i > StaticPass.SizeY - 16; i--)
                {
                    for(int j = 0; j < 15; j++)
                    {
                        if(presetPulsar[k] == '.')
                        {
                            SetAlive(j, i, false);
                        }
                        else
                        {
                            SetAlive(j, i, true);
                        }
                        k++;
                    }
                }
            break;
            case 3:
                //welcomeText.text += "Pentadecathlon";
                for(int i = StaticPass.SizeY - 1; i > StaticPass.SizeY - 10; i--)
                {
                    for(int j = 0; j < 16; j++)
                    {
                        Debug.Log("k: " + k + ", [" + j + "," + i + "]");
                        if (presetPentadecathlon[k] == '.')
                        {
                            //Debug.Log(i + " " + j + ".");
                            SetAlive(j, i, false);
                        }
                        else
                        {
                            //Debug.Log(i + " " + j + "O");
                            SetAlive(j, i, true);
                        }
                        k++;
                    }
                }
            break;
            case 4:
                //welcomeText.text += "Gospel Glider Gun";
                for (int i = StaticPass.SizeY-1; i > StaticPass.SizeY-10; i--)
                {
                    for (int j = 0; j < 36; j++)
                    {
                        if (presetGliderGun[k] == '.')
                        {
                            //Debug.Log(i + " " + j + ".");
                            SetAlive(j, i, false);
                        }
                        else
                        {
                            //Debug.Log(i + " " + j + "O");
                            SetAlive(j, i, true);
                        }
                        k++;
                    }
                }
                break;
            case 5:
                //welcomeText.text += "Random";
                for (int i = 0; i < StaticPass.SizeX; i++)
                {
                    for (int j = 0; j < StaticPass.SizeY; j++)
                    {
                        if(Random.value > 0.5)
                        {
                            SetAlive(i, j, true);
                        }
                        else
                        {
                            SetAlive(i, j, false);
                        }
                    }
                }
                break;
            case 6:
                //welcomeText.text += "Brain";
                //(int i = StaticPass.SizeY-1; i > StaticPass.SizeY-10; i--)
                for (int i = 10; i >= 0; i--)
                {
                    for (int j = StaticPass.SizeX-1; j > StaticPass.SizeX-18; j--)
                    {
                        if (presetBrain[k] == '.')
                        {
                            //Debug.Log(i + " " + j + ".");
                            SetAlive(j, i, false);
                        }
                        else
                        {
                            //Debug.Log(i + " " + j + "O");
                            SetAlive(j, i, true);
                        }
                        k++;
                    }
                }
                break;
            case 7:
                // Fountain
                for (int i = StaticPass.SizeY - 1; i > StaticPass.SizeY - 16; i--)
                {
                    for (int j = 0; j < 19; j++)
                    {
                        if (presetFountain[k] == '.')
                        {
                            //Debug.Log(i + " " + j + ".");
                            SetAlive(j, i, false);
                        }
                        else
                        {
                            //Debug.Log(i + " " + j + "O");
                            SetAlive(j, i, true);
                        }
                        k++;
                    }
                }
                break;
            case 8:
                // Fox
                for (int i = StaticPass.SizeY - 1; i > StaticPass.SizeY - 8; i--)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (presetFox[k] == '.')
                        {
                            //Debug.Log(i + " " + j + ".");
                            SetAlive(j, i, false);
                        }
                        else
                        {
                            //Debug.Log(i + " " + j + "O");
                            SetAlive(j, i, true);
                        }
                        k++;
                    }
                }
                break;
            case 9:
                // germ
                for (int i = StaticPass.SizeY - 1; i > StaticPass.SizeY - 11; i--)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (presetGerm[k] == '.')
                        {
                            //Debug.Log(i + " " + j + ".");
                            SetAlive(j, i, false);
                        }
                        else
                        {
                            //Debug.Log(i + " " + j + "O");
                            SetAlive(j, i, true);
                        }
                        k++;
                    }
                }
                break;
            case 10:
                // Smiley
                for (int i = StaticPass.SizeY - 1; i > StaticPass.SizeY - 9; i--)
                {
                    for (int j = 0; j < 7; j++)
                    {
                        if (presetSmiley[k] == '.')
                        {
                            Debug.Log(i + " " + j + ".");
                            SetAlive(j, i, false);
                        }
                        else
                        {
                            Debug.Log(i + " " + j + "O");
                            SetAlive(j, i, true);
                        }
                        k++;
                    }
                }
                break;
        }
    }

    private void Update()
    {
        //Debug.Log("Speed: "+StaticPass.Speed);
        waitTime = 5f / StaticPass.Speed;
        EditCells();
        timer += Time.deltaTime * Time.timeScale;
        if (timer > waitTime)
        {
            timer = 0f;
            CalculateNextStep();
            ExecuteNextStep();
        }

    }

    int GetAliveNeighbours(int x, int y)
    {
        int count = 0;
        int sizeX = StaticPass.SizeX;
        int sizeY = StaticPass.SizeY;

        // E
        if (x != sizeX - 1)
        {
            if (cells[x + 1, y].IsAlive)
            {
                count++;
            }
        }

        // SE
        if (x != sizeX - 1 && y != sizeY - 1)
        {
            if (cells[x + 1, y + 1].IsAlive)
            {
                count++;
            }
        }

        // S
        if (y != sizeY - 1)
        {
            if (cells[x, y + 1].IsAlive)
            {
                count++;
            }
        }

        // SW
        if (x != 0 && y != sizeY - 1)
        {
            if (cells[x - 1, y + 1].IsAlive)
            {
                count++;
            }
        }

        // W
        if (x != 0)
        {
            if (cells[x - 1, y].IsAlive)
            {
                count++;
            }
        }

        // NW
        if (x != 0 && y != 0)
        {
            if (cells[x - 1, y - 1].IsAlive)
            {
                count++;
            }
        }

        // N
        if (y != 0)
        {
            if (cells[x, y - 1].IsAlive)
            {
                count++;
            }
        }

        // NE
        if (x != sizeX - 1 && y != 0)
        {
            if (cells[x + 1, y - 1].IsAlive)
            {
                count++;
            }
        }
        //Debug.Log(x + " " + y + " neighbours: "+count);
        return count;
    }

    void EditCells()
    {
        if (Input.GetMouseButtonDown(0) && isEditable)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            for (int i = 0; i < StaticPass.SizeX; i++)
            {
                for (int j = 0; j < StaticPass.SizeY; j++)
                {
                    if (cells[i, j].square.GetComponent<Collider2D>().OverlapPoint(mousePosition))
                    {
                        if (cells[i, j].IsAlive)
                        {
                            SetAlive(i, j, false);
                        }
                        else
                        {
                            SetAlive(i, j, true);
                        }
                    }
                }
            }
        }
    }

    public void CalculateNextStep()
    {
        for (int i = 0; i < StaticPass.SizeX; i++)
        {
            for (int j = 0; j < StaticPass.SizeY; j++)
            {
                // Check the cell's current state, count its living neighbors, and apply the rules to set its next state.
                bool IsAlive = cells[i, j].IsAlive;
                int count = GetAliveNeighbours(i, j);
                bool result = false;

                if (IsAlive && count < 2)
                    result = false;
                if (IsAlive && (count == 2 || count == 3))
                    result = true;
                if (IsAlive && count > 3)
                    result = false;
                if (!IsAlive && count == 3)
                    result = true;

                cells[i, j].NextState = result;
            }
        }
    }

    public void ExecuteNextStep()
    {
        for (int i = 0; i < StaticPass.SizeX; i++)
        {
            for (int j = 0; j < StaticPass.SizeY; j++)
            {
                if (cells[i, j].NextState)
                {
                    SetAlive(i, j, true);
                }
                else
                {
                    SetAlive(i, j, false);
                }
            }
        }
    }


    void SetAlive(int i, int j, bool toggle)
    {
        if (toggle)
        {
            cells[i, j].IsAlive = true;
            cells[i, j].square.GetComponent<SpriteRenderer>().color = colorAlive;
        }
        else
        {
            cells[i, j].IsAlive = false;
            cells[i, j].square.GetComponent<SpriteRenderer>().color = colorDead;
        }
    }

    public void Pause(bool toggle)
    {
        if (toggle)
        {
            isPaused = true;
            Time.timeScale = 0;
        }
        else
        {
            isPaused = false;
            Time.timeScale = 1;
        }
    }


}