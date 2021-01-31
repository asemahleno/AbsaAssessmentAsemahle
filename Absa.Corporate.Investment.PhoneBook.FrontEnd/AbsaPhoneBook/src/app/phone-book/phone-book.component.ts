import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl} from '@angular/forms';
import { Entry, EntryClient, PhoneBook, PhoneBookClient } from 'src/@api/AbsaPhoneBookApi';
;

@Component({
  selector: 'app-phone-book',
  templateUrl: './phone-book.component.html',
  styleUrls: ['./phone-book.component.css']
})
export class PhoneBookComponent implements OnInit {
  constructor(private phoneBookClient: PhoneBookClient,
    private entryClient:EntryClient) {

  }

  phoneBooks: PhoneBook[]= [];
  showEditForm:boolean= false;
  showEntryInputs :boolean =false;
  phoneBook: PhoneBook = new PhoneBook({name:'',entries:[],id:0});
  entry:Entry = new Entry({name:'',phoneNumber:'',id:0,phoneBookId:0})
  showForm:boolean = false;
  searchTerm:string='';

  ngOnInit(): void {
  this.loadPhoneBooks();
  }

  onShowForm(){
    this.showForm = true;
  }

  onShowEditForm(name:string, id:any){
    this.showEditForm = true;
    this.phoneBook.name = name;
    this.phoneBook.id = id;
  }

  onHideEditForm(){
      this.showEditForm = false;
  }

  onHideOrEditInputs(){
    this.showEntryInputs = false;
    this.resetEntry();
  }

  onShowAddOrEditInputs(entry?:any,id?:any){
    if(entry){
      this.entry = entry
    }

    if(id && id>0){
      this.entry.phoneBookId = id;
     }

    this.showEntryInputs = true;
  }

  onSaveEntry(){
    this.entryClient.createOrUpdateEntry(this.entry).subscribe((response) =>{
      this.entry = response;
      this.loadPhoneBooks();

      this.onHideOrEditInputs();
      this.resetEntry();
      });
  }

  resetEntry(){
    this.entry = new Entry({name:'',phoneNumber:'',id:0,phoneBookId:0})
  }

  onDeleteEntry(id:any){
    this.entryClient.deleteEntry(id!).subscribe(success => {
      this.loadPhoneBooks();
    },
      error => {
      });
  }

  disableButton(){
    return this.showForm == true;
  }


  getTabLabel(phoneBook:PhoneBook): string{
    return phoneBook.name + " (" + phoneBook.entries?.length + ((phoneBook.entries?.length == 1)? ' entry)': " entries)")
  }

  onHideForm(){
    this.showForm = false;
  }

  onFilterEntries(phoneBook:PhoneBook){
    console.log('going in', phoneBook)
    var entriesMatchingSearchTerm:any = this.phoneBook.entries?.filter(x=> x.name.toLowerCase().startsWith(this.searchTerm) || (x.phoneNumber.toLowerCase().startsWith(this.searchTerm)));
    this.phoneBook.entries = entriesMatchingSearchTerm
    console.log('entries', this.phoneBook)
  };

  loadPhoneBooks(){
    this.phoneBookClient.getAll().subscribe((result )=>{
      this.phoneBooks = result;
     });
  }

  onSavePhoneBook(){
    this.phoneBookClient.createOrUpdatePhoneBook(this.phoneBook).subscribe((response) =>{
      this.phoneBook = response;
      this.loadPhoneBooks();

      if(this.phoneBook.id!> 0){
        this.onHideEditForm();
      }
      this.onHideForm();

      this.phoneBook.name='';
      });
  }

  onDelete(id:number|undefined) {
            this.phoneBookClient.deletePhoneBook(id!).subscribe(success => {
              this.loadPhoneBooks();
            },
              error => {
              });
          }
}
