import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { Instrument } from '../Models/instrument';

@Injectable({
  providedIn: 'root'
})
export class InstrumentService {

    private url = 'https://localhost:5001/api/Instruments';
    constructor(private http:HttpClient) { }
  
    public getInstruments() : Observable<Instrument[]>{
        return this.http.get<Instrument[]>(this.url);
    }
  }

