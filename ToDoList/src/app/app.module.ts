import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TodoItemListComponent } from './todo/todo-item-list/todo-item-list.component';
import { TodoModule } from "./todo/todo.module";

@NgModule({
    declarations: [
        AppComponent,
        TodoItemListComponent
        
    ],
    providers: [],
    bootstrap: [AppComponent],
    imports: [
        BrowserModule,
        AppRoutingModule,
        TodoModule,
        FormsModule
    ]
})
export class AppModule { }
