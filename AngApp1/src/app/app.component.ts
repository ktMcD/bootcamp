import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'AngApp1';
  headerText: string = "This is my cool new app!";
  components: string[] = ["Character", "Gear", "Monster", "Dungeon"];

  changeTitle(newTitle :string):void{
    this.title = newTitle;
    }

    addName(form:NgForm){
      let newName = form.form.value.name;
      this.components.push(newName);
    }

    
  }
