using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;

public class JsonManager : MonoBehaviour
{
    public class Sentence
    {
        public int index;
        public string actor;
        public string sentence;


        public Sentence(int index, string actor, string sentence)
        {
            this.index = index;
            this.actor = actor;
            this.sentence = sentence;
        }
    }
}
