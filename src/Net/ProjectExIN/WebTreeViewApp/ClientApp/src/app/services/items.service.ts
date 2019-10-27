import { Injectable, Inject } from "@angular/core";
import { Item } from "../models/Item";
import { HttpClient } from '@angular/common/http';

/**
 * Servicio Items 
 */
@Injectable({
    providedIn: 'root'
})
export class ItemService {

    constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

    /**
     * Retorna todos los items
     */
    GetAll(): Promise<Item[]> {
        return new Promise<Item[]>((resolve, reject) => {
            this.http.get<Item[]>(`${this.baseUrl}Items.json`).subscribe(
                (data) => {
                    resolve(data);
                },
                error => {
                    reject(error);
                },
            );
        });
    };
}
