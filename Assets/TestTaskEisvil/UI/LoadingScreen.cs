using System;
using ScarFramework.UI;
using TMPro;
using UnityEngine;

namespace TestTaskEisvil.UI
{
    public class LoadingScreen : UIScreen
    {
        [SerializeField] private TMP_Text description;
        [SerializeField] private RectTransform loadingIndicator;
        [SerializeField] private float indicatorRotationSpeed = 10f;

        private void Update()
        {
            if (loadingIndicator)
            {
                loadingIndicator.transform.Rotate(transform.forward, indicatorRotationSpeed * Time.deltaTime);
            }
        }
    }
}
