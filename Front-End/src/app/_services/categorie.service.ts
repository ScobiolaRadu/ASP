import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Categorie } from '../Models/categorie';

@Injectable({
  providedIn: 'root'
})
export class CategorieService {
  private url = 'https://localhost:5001/api/Categories';
  constructor(private http:HttpClient) { }

  public getCategories() : Observable<Categorie[]>{
      return this.http.get<Categorie[]>(this.url);
  }
}
