﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace WaveMaze{
	public class LevelManager : MonoBehaviour {
		List<LevelHandler> m_LevelList;
        GameObject m_CurrentLevelGo;
        SpriteRenderer m_SpriteRenderer;
        Sprite m_CurrentLevelGoundTexture;
        int m_CurrentLevel = 0;
        
		// Use this for initialization
		void Start() {
            
            m_CurrentLevelGo = new GameObject("m_CurrentLevelGo");
            m_SpriteRenderer = m_CurrentLevelGo.AddComponent<SpriteRenderer>();
            m_SpriteRenderer.sortingLayerName = "LevelLayer";
            addLevel(1);
            GameManager.Instance.FinishPreloading = true;
            StartLeve(1);
        }
		
		// Update is called once per frame
		void Update(){
			
		}

		void addLevel(int LevelCount){
			if (m_LevelList == null) {
				m_LevelList = new List<LevelHandler>();
			}
			m_LevelList.Add( new LevelHandler(LevelCount));
		}

		public void LoadLevel(int TheLevel){
			addLevel(TheLevel);
		}

        public void StartLeve(int TheLevel) {
            StartTransition();
            m_CurrentLevel = TheLevel;
            m_CurrentLevelGoundTexture = m_LevelList.Find(x => x.m_LevelNumber == TheLevel).LevelGround;
            
            Debug.Log("Width: " + m_CurrentLevelGoundTexture.rect.height.ToString() + "Width: " + m_CurrentLevelGoundTexture.rect.width.ToString());
            m_SpriteRenderer.sprite = m_CurrentLevelGoundTexture;
            m_SpriteRenderer.material = new Material( Shader.Find("Diffuse") );
        }

        void StartTransition() {

        }



    }
}
