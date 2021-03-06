import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http:HttpClient) { }

  postPortfolio(data:any){
    return this.http.post<any>("http://localhost:3000/portfolioDetails/",data);
  }
  getPortfolio(){
    return this.http.get<any>("http://localhost:3000/portfolioDetails/");
  }
  putPortfolio(data:any,id:number){
    return this.http.put<any>("http://localhost:3000/portfolioDetails/"+id,data);
  }
  deletePortfolio(id:number){
    return this.http.delete<any>("http://localhost:3000/portfolioDetails/"+id);
  }
}
