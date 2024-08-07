using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager: MonoBehaviour
{
    public TextMeshProUGUI playerNameText;
    public Slider energySlider;
    public TextMeshProUGUI goldText;
    public TextMeshProUGUI cashText;
    public Button dailyRewardButton;
    public Button dealsButton;
    public Button missionsButton;
    public Button eventsButton;
    public Button weaponsButton;
    public Button exitButton;
    public Button shareButton;
    public Button gamesButton;
    public Button settingsButton;
    public Toggle modeToggle;

    void Start()
    {
       
        playerNameText.text = "CAR: 5/75";
        energySlider.value = 6;
        goldText.text = "GOLD: 1000";
        cashText.text = "CASH: 1000";


        dailyRewardButton.onClick.AddListener(OnDailyRewardClicked);
        dealsButton.onClick.AddListener(OnDealsClicked);
        missionsButton.onClick.AddListener(OnMissionsClicked);
        eventsButton.onClick.AddListener(OnEventsClicked);
        weaponsButton.onClick.AddListener(OnWeaponsClicked);
        exitButton.onClick.AddListener(OnExitClicked);
        shareButton.onClick.AddListener(OnShareClicked);
        gamesButton.onClick.AddListener(OnGamesClicked);
        settingsButton.onClick.AddListener(OnSettingsClicked);
        modeToggle.onValueChanged.AddListener(OnModeToggleChanged);
    }

    void OnExitClicked()
    {
        Application.Quit();
    }
    
    void OnDailyRewardClicked()
    { 
        // Handle daily reward logic // 
    }
    void OnDealsClicked() 
    {
       // Handle deals logic //
       
    }
    void OnMissionsClicked() 
    { 
        // Handle missions logic //
    }
    void OnEventsClicked() 
    { 
        // Handle events logic //
    }
    void OnWeaponsClicked()
    {
        // Handle weapons logic // 
    }
    
    void OnShareClicked() 
    { 
        // Handle share logic //
    }
    void OnGamesClicked() 
    {
      // Handle games logic //
    }
    void OnSettingsClicked() 
    { 
        // Handle settings logic //
    }
    void OnModeToggleChanged(bool isFPS) 
    {
        // Handle mode toggle logic // 
    }
   
}

