import { Component, OnInit } from '@angular/core';
import {MatTableDataSource} from '@angular/material/table';


@Component({
  selector: 'app-stocks',
  templateUrl: './stocks.component.html',
  styleUrls: ['./stocks.component.css']
})
export class StocksComponent implements OnInit {
  displayedColumns: string[] = ['position', 'name', 'stockid', 'price','count'];
  dataSource = ELEMENT_DATA;
  
  constructor() { }

  ngOnInit(): void {
  }

}
export interface PeriodicElement {
  name: string;
  position: number;
  stockid: number;
  price: number;
  count:number;
}
const ELEMENT_DATA: PeriodicElement[] = [
  {position: 1, name: 'Reliance', stockid: 1120, price: 5000,count: 5},
  {position: 2, name: 'TCS', stockid: 1121, price: 10000,count: 7},
  {position: 3, name: 'HDFC Bank', stockid: 1122, price: 2000,count: 4},
  {position: 4, name: 'Infosys', stockid: 1123, price: 3000,count: 10},
  {position: 5, name: 'ICICI Bank', stockid: 1124, price: 10000,count: 6},
  {position: 6, name: 'Maruti Suzuki', stockid: 1125, price: 15000,count: 13},
  {position: 7, name: 'NTPC', stockid: 1126, price: 11000,count: 2},
  {position: 8, name: 'ONGC', stockid: 1127, price: 7000,count: 12},
  {position: 9, name: 'Tata Motors', stockid: 1128, price: 3000,count: 6},
  {position: 10, name: 'Bajaj Auto', stockid: 1129, price: 8000,count: 10},
];
