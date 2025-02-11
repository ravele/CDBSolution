import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, HttpClientModule, MatInputModule, MatButtonModule, MatCardModule],
  template: `
    <div class="container">
      <mat-card class="card">
        <h1 class="title">CDB Calculator</h1>
        <form [formGroup]="cdbForm" (ngSubmit)="calculate()">
          <mat-form-field class="full-width">
            <mat-label>Initial Value</mat-label>
            <input matInput formControlName="initialValue" type="number" />
          </mat-form-field>

          <mat-form-field class="full-width">
            <mat-label>Months</mat-label>
            <input matInput formControlName="months" type="number" />
          </mat-form-field>

          <button mat-raised-button color="primary" class="full-width" [disabled]="cdbForm.invalid">Calculate</button>
        </form>

        <mat-card *ngIf="result" class="result-card">
          <p><strong>Gross Amount:</strong> {{ result.gross | currency }}</p>
          <p><strong>Net Amount:</strong> {{ result.net | currency }}</p>
        </mat-card>
      </mat-card>
    </div>
  `,
  styles: [`
    .container {
      display: flex;
      justify-content: center;
      align-items: center;
      height: 100vh;
      background-color: #f5f5f5;
    }
    .card {
      width: 400px;
      padding: 20px;
    }
    .title {
      text-align: center;
      font-size: 1.5rem;
      margin-bottom: 20px;
    }
    .full-width {
      width: 100%;
    }
    .result-card {
      margin-top: 20px;
      padding: 10px;
      background-color: #e3f2fd;
    }
  `]
})
export class AppComponent {
  cdbForm: FormGroup;
  result: any;

  constructor(private fb: FormBuilder, private http: HttpClient) {
    this.cdbForm = this.fb.group({
      initialValue: ['', [Validators.required, Validators.min(1)]],
      months: ['', [Validators.required, Validators.min(2)]]
    });
  }

  calculate() {
    if (this.cdbForm.valid) {
      this.http.post('https://localhost:7173/api/cdb/calculate', this.cdbForm.value).subscribe(res => this.result = res);
    }
  }
}