import { Component, OnInit } from '@angular/core';
import { ListService } from '../list.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-lists-list',
  templateUrl: './lists-list.component.html',
  styleUrls: ['./lists-list.component.css']
})
export class ListsListComponent implements OnInit {
  lists: List[]
  listas = ["toto", "tutu", "titi"]
  strTest = "toto strTest"
  router: Router;

  public listService: ListService;
  constructor(listService: ListService, router: Router) { 
    this.listService = listService
    this.router = router
  }

  ngOnInit() {
    this.listService.getList().then((lists) => (this.lists = lists));
  }

  deleteElement(id: number){
    console.log("Deleting..." + id);
    if(confirm("Are you sure you want to delete this list ?")){
      this.listService.deleteList(id).then(i => this.ngOnInit());
    }
  }

  goToList(id: number){
    console.log("Going to " + id);
    this.router.navigate(['/items-lists', {listId: id}])
  }

  addList(event: any) {
    console.debug("adding...");
    this.listService
      .createList({
        name: event.target.listName.value,
      })
      .then(() => this.ngOnInit());
    
    
  }

  // testClick(){
  //   console.log("clicked");
    
  // }

}

interface List {
  id: number;
  name: string;
}
