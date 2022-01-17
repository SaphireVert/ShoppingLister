import { Component, Input, OnInit, Output, EventEmitter } from "@angular/core";
// import {  } from 'protractor';

@Component({
  selector: "app-item",
  templateUrl: "./item.component.html",
  styleUrls: ["./item.component.css"],
})
export class ItemComponent implements OnInit {
  @Input("testInput") testInput: string;
  @Output("testOutput") testOutput = new EventEmitter();

  constructor() {}

  ngOnInit() {}

  onClick() {
    console.log(this.testInput);
    this.testOutput.emit("Output click");
  }
}
