using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roulette_Manager : MonoBehaviour
{

    // lista de habilidades selecionadas
    public List<GameObject> choices;
    public List<GameObject> abilitiesSelectes;
    // Habilidades posibles
    [SerializeField] private List<GameObject> abilities;
    // auxiliares
    private int random;
    private bool entry;
    // aqui vamos a elegir las Habilidades que vamos a mostrar
    public void choiceAbilities()
    {
        for (int i = 0; i < choices.Count; i++)
        {
            do
            {   

                random = Random.Range(0, 5);
                entry = false;
            } while (entry);
            entry = true;
        }
    }
    public void selectAbilitie(GameObject choice)
    {
        abilitiesSelectes.Add(choice);
    }
}
