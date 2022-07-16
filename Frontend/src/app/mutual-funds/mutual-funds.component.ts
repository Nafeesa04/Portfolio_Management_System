import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-mutual-funds',
  templateUrl: './mutual-funds.component.html',
  styleUrls: ['./mutual-funds.component.css']
})
export class MutualFundsComponent implements OnInit {

  displayedColumns: string[] = ['position', 'name', 'stockid', 'price','count','return'];
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
  return:string;
}
const ELEMENT_DATA: PeriodicElement[] = [
  {position: 1, name: 'Tata Digital India Fund', stockid:1011, price: 5000,count: 5,return:'28.35%'},
  {position: 2, name: 'ICICI Prudential Technology Fund', stockid: 1012, price: 10000,count: 7,return:'19.25%'},
  {position: 3, name: 'Aditya Birla Sun Life Digital India Fund ', stockid: 1013, price: 2000,count: 4,return:'27.30%'},
  {position: 4, name: 'SBI Technology Opportunities Fund', stockid: 1014, price: 3000,count: 10,return:'15.35%'},
  {position: 5, name: 'Franklin India Technology Fund', stockid: 1015, price: 10000,count: 6,return:'24.16%'},
  
];

