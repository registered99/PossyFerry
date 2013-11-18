﻿using UnityEngine;
using System.Collections;

public class Player : FSprite {
	
    // last shot time
    private float last_shot_time;
    private ShotStrategy _shotStrategy;

	public Player() : base("Banana")
	{
	}

    public void setShotStrategy( ShotStrategy _shotStrategy )
    {
        this._shotStrategy = _shotStrategy;
    }
	
	public void playerDeath()
	{
		//return player to the middle of the screen
		this.x = 0;
		this.y = 0;
		
		//decrease the number of player's lives
		Main.instance.lives--;
		if(Main.instance.lives <= 0)
		{
			Main.instance._livesLabel.text = "Player's Lives: " + Main.instance.lives;
			Main.instance.GoToPage(PageType.GameOverPage);
			return;
		}
		else
		{
			Main.instance._livesLabel.text = "Player's Lives: " + Main.instance.lives;
		}
		
		
		//handle any death consequences
	}

    public void shoot()
    {
        if( Time.time-last_shot_time > 0.15 ){
            _shotStrategy.shoot(this.x, this.y, false);
            last_shot_time = Time.time;
        }
    }
	
}
