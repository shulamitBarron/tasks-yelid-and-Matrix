import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';
import { AuthGuard } from './shared/auth.guard';
import { AccountComponent } from './components/account/account.component';
import { ProductsComponent } from './components/products/products.component';
import { RegisterComponent } from './components/register/register.component';
import { ProductPreviewComponent } from './components/product-preview/product-preview.component';
import { CartProductComponent } from './components/cart-product/cart-product.component';
import { MainComponent } from './components/main/main.component';

const appRoutes: Routes = [
    {
        path: 'account', component: AccountComponent, children: [
            { path: 'login', component: LoginComponent },
            { path: 'register', component: RegisterComponent }
        ]
    },
    {
        path: 'products', component: ProductsComponent, children: [
            { path: 'productpreview', component: ProductPreviewComponent }
        ]
    },
    {
        path: 'cart', component: AccountComponent, canActivate: [AuthGuard], children: [
            { path: 'cart_product', component: CartProductComponent }
        ]
    }
    ,
// default  main's level  redirect to home
{ path: '**',component: HomeComponent }
];

export const routing = RouterModule.forRoot(appRoutes);
