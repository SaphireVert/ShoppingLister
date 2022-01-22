import { Component, OnInit } from '@angular/core';
import { ListService } from '../list.service';

@Component({
  selector: 'app-lists-list',
  templateUrl: './lists-list.component.html',
  styleUrls: ['./lists-list.component.css']
})
export class ListsListComponent implements OnInit {
  lists: List[]
  listas = ["toto", "tutu", "titi"]
  strTest = "toto strTest"

  public listService: ListService;
  constructor(listService: ListService) { 
    this.listService = listService
  }

  ngOnInit() {
    this.listService.getList().then((lists) => (this.lists = lists));
  }

  deleteElement(id: number){
    console.log("Deleting..." + id);
    
  }

}

interface List {
  id: number;
  name: string;
}
