using UnityEngine;
using System.Collections;
using System;

public class WinPage: PageContatiner
{
  private FButton _backButton;
  private FSprite _background;
  private FLabel _winLabel;
  public WinPage ()
  {
    //initialize
    _background = new FSprite("background_1_blur");
    _backButton = new FButton("YellowButton_normal", "YellowButton_down", "YellowButton_over", "ClickSound");
    _backButton.AddLabel("Franchise", "Back", new Color(0.25f,0.25f,0.25f,1.0f));
    _winLabel = new FLabel("Franchise", "Win Over for you!!!");
    _winLabel.color = new Color(1.0f,1.0f,1.0f,1.0f);

    //position back button
    _backButton.x = -Futile.screen.halfWidth + 70.0f;
    _backButton.y = Futile.screen.halfHeight - 30.0f;

    //add to the stage
    AddChild(_background);
    AddChild(_backButton);
    AddChild(_winLabel);
    _backButton.SignalRelease += HandleBackButtonRelease;

  }
  private void HandleBackButtonRelease(FButton fbutton)
  {
    Main.instance.GoToPage(PageType.TitlePage);
  }
}

