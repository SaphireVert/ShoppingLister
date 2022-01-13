import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from "@angular/common/http";

@Component({
  selector: "app-notes-list",
  templateUrl: "./notes-list.component.html",
  styleUrls: ["./notes-list.component.css"],
})
export class NotesListComponent implements OnInit {
  public notes: Note[];

  constructor(http: HttpClient, @Inject("BASE_URL") baseUrl: string) {
    http.get<Note[]>(baseUrl + "notes/getAll").subscribe(
      (result) => {
        this.notes = result;
        console.debug(this.notes);
      },
      (error) => console.error(error)
    );
  }
  ngOnInit() {}
  public edit() {
    console.debug("editing...")
  }
  public delete() {
    console.debug("deleting...")
  }
  
}
interface Note {
  id: number;
  title: string;
  content: string;
}
