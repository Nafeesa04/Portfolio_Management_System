import { CurrencyPipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-asset-sales',
  templateUrl: './asset-sales.component.html',
  styleUrls: ['./asset-sales.component.css']
})
export class AssetSalesComponent implements OnInit {

  displayedColumns: string[] = ['position', 'name', 'status', 'price'];
  dataSource = ELEMENT_DATA;

  constructor() { }

  ngOnInit(): void {
  }

}
export interface PeriodicElement {
  name: string;
  position: number;
  price: string;
  status:string;
}
const ELEMENT_DATA: PeriodicElement[] = [
  {position: 1, name: 'Tata Digital India Fund', status:'True', price:'50,000$'},
  {position: 2, name: 'ICICI Prudential Technology Fund', status: 'False', price: '10,000$'},
  {position: 3, name: 'Aditya Birla Sun Life Digital India Fund ', 'status': 'True', price: '20,000$'},
  {position: 4, name: 'SBI Technology Opportunities Fund', status: 'True', price: '30,000$'},
  {position: 5, name: 'Franklin India Technology Fund', status: 'True', price: '10,000$'},
  
];

