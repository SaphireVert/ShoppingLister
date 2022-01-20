import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { ItemsListsComponent } from './items-lists/items-lists.component';
import { ItemComponent } from './item/item.component';
import { SideMenuComponent } from './side-menu/side-menu.component';
import { LoadingComponent } from './loading/loading.component';
import { CategoryListComponent } from './category-list/category-list.component';
import { ListElementComponent } from './list-element/list-element.component';
import { CrudTableComponent } from './crud-table/crud-table.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    ItemsListsComponent,
    ItemComponent,
    SideMenuComponent,
    SideMenuComponent,
    LoadingComponent,
    CategoryListComponent,
    ListElementComponent,
    CrudTableComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: "ng-cli-universal" }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: "", component: HomeComponent, pathMatch: "full" },
      { path: "items-lists", component: ItemsListsComponent },
      { path: "category-list", component: CategoryListComponent },
    ]),
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
