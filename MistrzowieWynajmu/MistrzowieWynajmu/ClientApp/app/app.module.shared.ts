import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';

//***Properties Section***\\
import { PropertiesComponent } from './components/properties/components/properties.component';
import { PropertiesService } from './components/properties/services/properties.service';
import { PropertiesBackedService } from './services/properties-backend.service';
import { HttpPropertiesBackedService } from './services/http-properties-backend.service';
import { PropertyDetailsComponent } from './components/properties/components/property-details.component';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        HomeComponent,
        PropertiesComponent,
        PropertyDetailsComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: 'properties', component: PropertiesComponent },
            { path: 'properties/new-property', component: PropertyDetailsComponent },
            { path: 'properties/property-details/:id', component: PropertyDetailsComponent },
            { path: 'properties/property-update/:id', component: PropertyDetailsComponent },
            { path: '**', redirectTo: 'properties' }
        ])
    ],
    providers: [
        PropertiesService, { provide: PropertiesBackedService, useClass: HttpPropertiesBackedService }
    ]
})
export class AppModuleShared {
}
