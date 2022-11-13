using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Gaia
{
    public class weathersel : MonoBehaviour
    {
        public int selection = 0;
        public GaiaSceneLighting gi;
        // Start is called before the first frame update
        void Start()
        {
            GaiaSettings gaiaSettings = GaiaUtils.GetGaiaSettings();
            if(selection == 0)
            {
                Debug.Log(gaiaSettings.m_gaiaLightingProfile);
            }
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}
