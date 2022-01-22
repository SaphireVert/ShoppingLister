import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-crud-table',
  templateUrl: './crud-table.component.html',
  styleUrls: ['./crud-table.component.css']
})
export class CrudTableComponent implements OnInit {

  addFields = ["name"]
  header: ["toto", "tutu", "titi"]

  data = {
    header: ["toto", "tutu", "titi"],
    rows:[]
  }
  constructor() { }

  ngOnInit() {
  }

}
