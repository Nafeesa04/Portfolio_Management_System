import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-services',
  templateUrl: './services.component.html',
  styleUrls: ['./services.component.css']
})
export class ServicesComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }
  services=[
    {'name':'Portfolio Details','image':'../../assets/portfolio.jpg'},
    {'name':'Stock Details','image':'../../assets/stock.jpg'},
    {'name':'Mutual Fund Details','image':'../../assets/Mutual Fund.jpg'},
    {'name':'AssetSale Response','image':'../../assets/sales.jpg'},
  ]

}
