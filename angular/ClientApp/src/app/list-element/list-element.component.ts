import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-list-element',
  templateUrl: './list-element.component.html',
  styleUrls: ['./list-element.component.css']
})
export class ListElementComponent implements OnInit {
  @Input("infosInput") infosInput: List
  @Output("deleteEventOutput") deleteEventOutput = new EventEmitter();
  @Output("goToEventOutput") goToEventOutput = new EventEmitter();

  // test = "test"
  // elementInfos = ["toto", "tutu", "titi"]
  
  constructor() { 
    
  }

  ngOnInit() {
    console.log("this.infosInput");
    console.log(this.infosInput);
  }

  delete() {
    this.deleteEventOutput.emit(this.infosInput.id);
  }

  goTo(id:number) {
    this.goToEventOutput.emit(this.infosInput.id);
  }


}

interface List {
  id: number;
  name: string;
}
