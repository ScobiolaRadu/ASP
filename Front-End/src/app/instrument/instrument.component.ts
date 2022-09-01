import { Component, OnInit, ɵAPP_ID_RANDOM_PROVIDER } from '@angular/core';
import { Instrument } from '../Models/instrument';
import { InstrumentService } from '../_services/instrument.service';

@Component({
  selector: 'app-instrument',
  templateUrl: './instrument.component.html',
  styleUrls: ['./instrument.component.css']
})
export class InstrumentComponent implements OnInit {

  instruments: Instrument[] = [];
  constructor(private instrumentService:InstrumentService) { }

  ngOnInit(): void {
    this.instrumentService
    .getInstruments()
    .subscribe((result:Instrument[]) => (this.instruments = result));
  }

}
