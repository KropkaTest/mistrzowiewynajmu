import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import { Property } from '../../../models/property';
import { PropertiesBackedService } from '../../../services/properties-backend.service';

@Injectable()
export class PropertiesService {
    constructor(private propertiesBackedService: PropertiesBackedService) { }

    addProperty(newProperty: Property): Observable<number> {
        return this.propertiesBackedService.addProperty(newProperty);
    }
    getProperty(id: number): Observable<Property> {
        return this.propertiesBackedService.getProperty(id);
    }
    getProperties(): Observable<Property[]> {
        return this.propertiesBackedService.getProperties();
    }    
    updateProperty(updatedProperty: Property): Observable<number> {
        return this.propertiesBackedService.updateProperty(updatedProperty);
    }    
    deleteProperty(id: number): Observable<number> {
        return this.propertiesBackedService.deleteProperty(id);
    }
}
