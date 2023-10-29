import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable, interval, map, of, switchMap, take } from 'rxjs';
import { API_BASE_URL } from 'src/app/app.module';
import {
  BaseAutoDto,
  Engine,
  Generation,
  SaleAnnouncement,
  SearchRequest,
} from '../interfaces/Auto';
import * as moment from 'moment';

interface ApiSaleAnnouncement extends Omit<SaleAnnouncement, 'createdAt'> {
  createdAt: string;
}

@Injectable({
  providedIn: 'root',
})
export class AutoService {
  private readonly baseUrl = `${this.apiBaseUrl}/auto`;
  constructor(
    private httpClient: HttpClient,
    @Inject(API_BASE_URL) private apiBaseUrl: string
  ) {}

  public getBrands(): Observable<BaseAutoDto[]> {
    return this.httpClient.get<BaseAutoDto[]>(`${this.baseUrl}/brands`);
  }

  public getModels(
    brandId: number,
    search?: string
  ): Observable<BaseAutoDto[]> {
    const queryParams = new URLSearchParams({ brand: `${brandId}` });
    if (search) {
      queryParams.append('search', search);
    }

    return this.httpClient.get<BaseAutoDto[]>(
      `${this.baseUrl}/models?${queryParams.toString()}`
    );
  }

  public getGenerations = (
    modelId: number,
    search?: string
  ): Observable<Generation[]> => {
    const queryParams = new URLSearchParams({ model: `${modelId}` });
    if (search) {
      queryParams.append('search', search);
    }

    return this.httpClient.get<Generation[]>(
      `${this.baseUrl}/generations?${queryParams.toString()}`
    );
  };

  public getEngines(modelId: number, search?: string): Observable<Engine[]> {
    const queryParams = new URLSearchParams({ model: `${modelId}` });
    if (search) {
      queryParams.append('search', search);
    }

    return this.httpClient.get<Engine[]>(
      `${this.baseUrl}/engines?${queryParams.toString()}`
    );
  }

  public getEquipments(modelId: number): Observable<BaseAutoDto[]> {
    const queryParams = new URLSearchParams({ model: `${modelId}` });

    return this.httpClient.get<BaseAutoDto[]>(
      `${this.baseUrl}/equipments?${queryParams.toString()}`
    );
  }

  private mapApiSaleAnnouncement(apiSaleAnnouncement: ApiSaleAnnouncement) {
    const { createdAt, ...announcement } = apiSaleAnnouncement;
    return { ...announcement, createdAt: moment(createdAt) };
  }

  public getSaleAnnouncements = (
    search: SearchRequest
  ): Observable<SaleAnnouncement[]> => {
    const params = Object.fromEntries(
      Object.entries({
        brand: `${search.brand}`,
        models: search.models.join(',') ?? '',
        generations: search.generations?.join(',') ?? '',
        priceFrom: search.price.from?.toString() ?? '',
        priceTo: search.price.to?.toString() ?? '',
        yearFrom: search.year.from?.toString() ?? '',
        yearTo: search.year.to?.toString() ?? '',
        mileageFrom: search.mileage.from?.toString() ?? '',
        mileageTo: search.mileage.to?.toString() ?? '',
      }).filter(([, value]) => value !== '')
    );
    const queryParams = new URLSearchParams(params);

    return this.httpClient
      .get<ApiSaleAnnouncement[]>(
        `${this.apiBaseUrl}/announcements?${queryParams.toString()}`
      )
      .pipe(map((x) => x.map(this.mapApiSaleAnnouncement)));
  };

  public getSaleAnnouncement = (id: number): Observable<SaleAnnouncement> => {
    return interval(1000).pipe(
      take(1),
      switchMap(() =>
        this.httpClient
          .get<ApiSaleAnnouncement>(`${this.apiBaseUrl}/announcements/${id}`)
          .pipe(map(this.mapApiSaleAnnouncement))
      )
    );
  };
}
