using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace R60N.Utility
{
    public static class Random60N
    {
        public class WeightedList<T>
        {
            public float WeightSum { get; private set; }

            List<WeightedElement<T>> list = new List<WeightedElement<T>>();

            public void Add(T value, float weight)
            {
                WeightSum += weight;
                list.Add(new WeightedElement<T>(value, weight));
            }

            public T Get(float weight)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (weight <= list[i].Weight)
                        return list[i].Value;

                    weight -= list[i].Weight;
                }

                return list[list.Count - 1].Value;
            }

            class WeightedElement<T>
            {
                public T Value;
                public float Weight;

                public WeightedElement(T value, float weight)
                {
                    Value = value;
                    Weight = weight;
                }
            }
        }
    }
}
