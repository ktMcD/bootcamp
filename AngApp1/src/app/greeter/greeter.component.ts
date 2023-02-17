import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-greeter',
  templateUrl: './greeter.component.html',
  styleUrls: ['./greeter.component.css']
})
export class GreeterComponent {
    @Input() name = "Fred";
    @Input() favoriteNumber : number = 7;
    showStory: boolean = false;
    buttonText: string = "Show";

    toggleStory():void{
      this.showStory = !this.showStory;
      if(this.showStory){
        this.buttonText = "Hide";
      }
      else{
        this.buttonText = "Show";
      }
    }

    weapons : string[] = [ "knife","sword","bow & arrow","wand"];

    goldAmount: number = 100;
    healthPercent: number = .75;

}
