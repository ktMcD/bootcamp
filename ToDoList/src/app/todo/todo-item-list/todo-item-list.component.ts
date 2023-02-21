import { Component, Input } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ITodoList } from '../interfaces/todo-list';

@Component({
  selector: 'app-todo-item-list',
  templateUrl: './todo-item-list.component.html',
  styleUrls: ['./todo-item-list.component.css']
})
export class TodoItemListComponent {
  items : ITodoList[] = [
    {id: 1, task: "Thing 1",completed : false},
    {id: 2, task: "Thing 2",completed : false},
    {id: 3, task: "Thing 3",completed : false},
    {id: 4, task: "Thing 4",completed : false},
    {id: 5, task: "Thing 5",completed : false},
    {id: 6, task: "Thing 6",completed : false},
    {id: 7, task: "Thing 7",completed : false},
    {id: 8, task: "Thing 8",completed : false}
  ]
  @Input() task : string = "";

  ngOnInit(): void {
    this.items = this.getAllItems();
  }

  getAllItems(): ITodoList[] {
    return this.items
  }
  markItemComplete(form:NgForm) : void {
    // still need to figure out how to get the value
  }
  
  addItem(form:NgForm) : void {
    var nextId : number = this.items.length;
    let task = form.form.value.task;
    this.items.push({id:nextId, task:task, completed:false});
  }
}