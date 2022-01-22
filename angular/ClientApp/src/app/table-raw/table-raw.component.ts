import { Component, OnInit, Input, Output, EventEmitter, ViewEncapsulation } from '@angular/core';

@Component({
  selector: '[table-raw]',
  templateUrl: './table-raw.component.html',
  styleUrls: ['./table-raw.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class TableRawComponent implements OnInit {

  @Input("elements") elements: string[];
  @Output("deleteOutput") deleteOutput = new EventEmitter();
  // @Output("editOutput") rawOutput = new EventEmitter();

  

  constructor() { }

  ngOnInit() {
  }

  delete() {
    console.log("totooooooooooooooo");
    console.log(this.elements);
    this.deleteOutput.emit("Output delete click");
  }

}
