import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';
import { LoginComponent } from './login/login.component';
import { SignupComponent } from './signup/signup.component';
import { PortfolioComponent } from './portfolio/portfolio.component';
import { ServicesComponent } from './services/services.component';
import { StocksComponent } from './stocks/stocks.component';
import { MutualFundsComponent } from './mutual-funds/mutual-funds.component';
import { AssetSalesComponent } from './asset-sales/asset-sales.component';
import { DialogComponent } from './dialog/dialog.component';
const routes: Routes = [
  {path:'',component:HomeComponent},
  {path:'About',component:AboutComponent},
  {path:'Login',component:LoginComponent},
  {path:'SignUp',component:SignupComponent},
  {path:'Services',component:ServicesComponent},
  {path:'Portfolio',component:PortfolioComponent},
  {path:'Stocks',component:StocksComponent},
  {path:'MutualFunds',component:MutualFundsComponent},
  {path:'AssetSales',component:AssetSalesComponent},
  {path:'dialog',component:DialogComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
