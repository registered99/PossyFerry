﻿using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum PageType
{
  None,
    TitlePage,
    GamePage,
    OptionPage,
    CreditPage,
    GameOverPage,
    WinPage
}

public class Main : MonoBehaviour
{
  public BCharacter character;
  public GamePage gamePage;
  public static Main instance;
  public ControlScheme controlScheme;

  //Initialize The player's lives.
  public FLabel _livesLabel;
  public int lives = 3;

  private PageContatiner _currentPage = null;
  private PageType _currentPageType = PageType.None;
  private FStage _stage;
  // Use this for initialization
  void Start () {
    controlScheme = new TouchControlScheme();
    instance = this;
    FutileParams fparams = new FutileParams(true,true,false,false);
    fparams.AddResolutionLevel(1280.0f, 2.0f, 2.0f, "_Scale2");
    fparams.origin = new Vector2(0.5f, 0.5f);
    Futile.instance.Init(fparams);
    //load atlasses
    Futile.atlasManager.LoadAtlas("Atlases/BananaLargeAtlas");
    Futile.atlasManager.LoadAtlas("Atlases/BananaGameAtlas");

    Futile.atlasManager.LoadAtlas("Atlases/Fish-test/Fish-test");
    Futile.atlasManager.LoadAtlas("Atlases/Fish-test/large-fish");

    Futile.atlasManager.LoadFont("Franchise","FranchiseFont"+Futile.resourceSuffix, "Atlases/FranchiseFont"+Futile.resourceSuffix, 0.0f,-4.0f);

    _stage = Futile.stage;
    //go to this page when starts the game
    GoToPage(PageType.GamePage);
  }

  public void GoToPage(PageType pageType)
  {
    if(_currentPageType == pageType) return;
    PageContatiner pageToCreate = null;
    if(pageType == PageType.TitlePage)
    {
      pageToCreate = new TitlePage();
    }
    else if(pageType == PageType.GamePage)
    {
      pageToCreate = new GamePage();	
    }
    else if(pageType == PageType.OptionPage)
    {
      pageToCreate = new OptionPage();	
    }
    else if(pageType == PageType.CreditPage)
    {
      pageToCreate = new CreditPage();	
    }
    else if(pageType == PageType.GameOverPage)
    {
      pageToCreate = new GameOverPage();
    }
    else if(pageType == PageType.WinPage)
    {
      pageToCreate = new WinPage();
    }

    if(pageToCreate != null)
    {
      _currentPageType = pageType;
      if(_currentPage != null)
      {
        _stage.RemoveChild(_currentPage);
      }

      _currentPage = pageToCreate;
      _stage.AddChild(_currentPage);
      _currentPage.Start();
    }
  }
}
