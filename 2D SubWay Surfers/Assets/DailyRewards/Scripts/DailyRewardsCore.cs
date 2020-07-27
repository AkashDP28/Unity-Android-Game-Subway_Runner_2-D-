/***************************************************************************\
Project:      Daily Rewards
Copyright (c) Niobium Studios
Author:       Guilherme Nunes Barbosa (gnunesb@gmail.com)
\***************************************************************************/
using System;
using System.Globalization;
using UnityEngine;
using System.Collections;

namespace NiobiumStudios
{
    /**
     * Daily Rewards common methods
     **/
    public abstract class DailyRewardsCore<T> : MonoBehaviour where T : DailyRewardsCore<T>
    {
        public bool isSingleton = true;                         // Checks if should be used as singleton

        public string errorMessage;                             // Error Message
        public bool isErrorConnect;                             // Some error happened on connecting?
        public DateTime now;                                    // The actual date. Either returned by the using the world clock or the player device clock

        public int maxRetries = 3;                              // The maximum number of retries for the World Clock connection

        public delegate void OnInitialize(bool error = false, string errorMessage = ""); // When the timer initializes. Sends an error message in case it happens. Should wait for this delegate if using World Clock API
        public OnInitialize onInitialize;

        public bool isInitialized = false;
		private static T _instance;

        // Initializes the current DateTime. If the player is using the World Clock initializes it
        public void InitializeDate()
        {
	        now = DateTime.Now;
	        isInitialized = true;
        }

        public void RefreshTime ()
        {
            now = DateTime.Now;
        }

		public static T instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = FindObjectOfType<T>();
					if (_instance == null)
					{
						GameObject obj = new GameObject();
						obj.hideFlags = HideFlags.HideAndDontSave;
						_instance = obj.AddComponent<T>();
					}
				}
				
				return _instance;
			}
		}

        //Updates the current time
        public virtual void TickTime()
        {
            if (!isInitialized)
				return;

            now = now.AddSeconds(Time.unscaledDeltaTime);
        }

        public string GetFormattedTime (TimeSpan span)
        {
            return string.Format("{0:D2}:{1:D2}:{2:D2}", span.Hours, span.Minutes, span.Seconds);
        }

        protected virtual void Awake()
        {
			if (isSingleton)
				DontDestroyOnLoad(this.gameObject);
			
			if (_instance == null)
				_instance = this as T;
			else
				Destroy(gameObject);
        }

        protected virtual void OnApplicationPause(bool pauseStatus)
        {
            if(!pauseStatus)
            {
                RefreshTime();
            }                
        }
    }
}