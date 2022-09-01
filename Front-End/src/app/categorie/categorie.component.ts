import { Component, OnInit } from '@angular/core';
import { Categorie } from '../Models/categorie';
import { CategorieService } from '../_services/categorie.service';

@Component({
  selector: 'app-categorie',
  templateUrl: './categorie.component.html',
  styleUrls: ['./categorie.component.css']
})
export class CategorieComponent implements OnInit {
 
  categories: Categorie[] = [];

  constructor(private categorieService: CategorieService) { }

  ngOnInit(): void {
    this.categorieService
    .getCategories()
    .subscribe((result:Categorie[]) => (this.categories = result));

  }

}
