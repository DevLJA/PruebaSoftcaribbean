import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { APIService } from 'src/app/API/api.service';

export class PacientRelation {
  constructor(
    public NmidMedicotra: Number,
    public Dseps: string,
    public Dsarl: string,
    public Cdusuario: string,
    public Dscondicion: string) { }
}

@Component({
  selector: 'app-Person',
  templateUrl: './Person.component.html',
  styleUrls: ['./Person.component.css']
})
export class PersonComponent implements OnInit {
  form: any;
  personType: any;
  genders: any;
  people: any;
  medical: any;
  style: any;
  PacienteNmidMedicotraNavigations: any;
  submitted = false;
  constructor(private formBuilder: FormBuilder, private API: APIService) {
  }
  get f() { return this.form.controls; }
  onSubmit() {
    this.submitted = true;

    if (this.form.invalid) {
      return;
    }
    this.form.value.PacienteNmidMedicotraNavigations = new Array;
    this.form.value.PacienteNmidMedicotraNavigations.push(new PacientRelation
      (
        this.form.value.NmidMedicotra,
        this.form.value.Dseps,
        this.form.value.Dsarl,
        this.form.value.Cdusuario,
        this.form.value.Dscondicion,
      ));
    this.API.sendFormNewPerson(this.form.value).subscribe(response => {
      alert(response);
      for (var name in this.form.controls) {
        (this.form.controls[name]).updateValue('');
        this.form.controls[name].setErrors(null);
      }
    });
  }

  onChange(personDocument: any) {
    console.log('Cambio');
    var showInfo = this.people.filter((x: any) => x.Cddocumento === personDocument);
    console.log(showInfo);
    this.form = this.formBuilder.group({
      Cddocumento: [showInfo.cddocumento, Validators.required],
      Dsnombres: ['', Validators.required],
      Dsapellidos: ['', Validators.required],
      Fenacimiento: ['', Validators.required],
      Cdtipo: ['', Validators.required],
      Cdgenero: ['', Validators.required],
      Dsdireccion: ['', Validators.required],
      CdtelfonoFijo: ['', Validators.required],
      CdtelefonoMovil: ['', Validators.required],
      DsEmail: ['', [Validators.required, Validators.email]],
      NmidMedicotra: ['', []],
      Dseps: ['', []],
      Dsarl: ['', []],
      Cdusuario: ['', []],
      Dscondicion: ['', []]
    });
  }

  ngOnInit() {
    this.style = "style='display:block'";
    this.form = this.formBuilder.group({
      Cddocumento: ['', Validators.required],
      Dsnombres: ['', Validators.required],
      Dsapellidos: ['', Validators.required],
      Fenacimiento: ['', Validators.required],
      Cdtipo: ['', Validators.required],
      Cdgenero: ['', Validators.required],
      Dsdireccion: ['', Validators.required],
      CdtelfonoFijo: ['', Validators.required],
      CdtelefonoMovil: ['', Validators.required],
      DsEmail: ['', [Validators.required, Validators.email]],
      NmidMedicotra: ['', []],
      Dseps: ['', []],
      Dsarl: ['', []],
      Cdusuario: ['', []],
      Dscondicion: ['', []]
    });
    this.API.getAllGender().subscribe(
      response => {
        this.genders = response.response;
      }
    );
    this.API.getAllPersonType().subscribe(
      response => {
        this.personType = response.response;
      }
    );
    this.API.getAll().subscribe(
      response => {
        this.people = response.response;
      }
    );
    this.API.getAllMedical().subscribe(
      response => {
        this.medical = response.response;
      }
    );
  }
}
