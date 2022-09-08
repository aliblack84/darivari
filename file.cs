#include <stdio.h>
#include <conio.h>
#include <ctype.h>
#include <stdlib.h>
#include <string.h>
#include <dos.h>
int i = 0; //Global Variable
//=================DECLARATION OF VARIOUS FUNCTIONS===========================
void login();
void design();
void course();
void course_entry();
void help();
void help1();
void about();
void main_box();
int course_id();
void updt_course();
void show_course();
long int stud_id();
void stud_menu();
void stud_entry();
void show_stud();
void updt_stud();
void stud_detail();
void pend_doc();
void stud_doc();
void fees();
void fees_str();
void fee_pay();
void fee_pend();
void rept_main();
void rept_stud();
void rept_fee();
void bill(long int p, char q[20], char r[20], long int s, long int t);
int tim();
//=====================DECLARATION OF STRUCTURES=============================
struct stud
{
  long int f_no;
  char s_nam[20], add[50], dob[15], m_no[15], cors[10], nat[15];
  char res10[5], res12[5], natp[5], addp[5], tc[5], lc[5];
} st;
struct stud_exam
{
  char exam[20], uni[30], year[10], per[10], clas[20];
} se[50];
struct course_enter
{
  int c_id, dur;
  long int fees;
  char c_nam[25];
} ce;
struct payment
{
  long int total, paid, c_total;
} pay;
 
FILE *fp;
//==========================VALIDATION FUNCTION===============================
void validation(char t[], int code)
{
  int x = 0;
  if (code == 0)
  {
    while ((t[x] = getch()) != '\r' && x < 30)
      if ((t[x] >= 97 && t[x] <= 122) || (t[x] >= 65 && t[x] <= 90) || t[x] == 32 || t[x] == '_')
      {
        printf("%c", t[x]);
        x++;
      }
      else if (t[x] == 8 && x > 0)
      {
        printf("%c%c%c", 8, 32, 8);
        x--;
      }
  }
  else if (code == 1)
  {
    while ((t[x] = getch()) != '\r' && x < 10)
      if ((t[x] >= 48 && t[x] <= 57) || t[x] == 46 || t[x] == '_')
      {
        printf("%c", t[x]);
        x++;
      }
      else if (t[x] == 8 && x > 0)
      {
        printf("%c%c%c", 8, 32, 8);
        x--;
      }
  }
  else if (code == 2)
  {
    while ((t[x] = getch()) != '\r' && x < 30)
      if ((t[x] >= 97 && t[x] <= 122) || (t[x] >= 65 && t[x] <= 90) || (t[x] == 48 && t[x] <= 57) || t[x] == 32 || t[x] == 8 || t[x] == '@' || t[x] == '.')
      {
        printf("%c", t[x]);
        x++;
      }
      else if (t[x] == 8 && x > 0)
      {
        printf("%c%c%c", 8, 32, 8);
        x--;
      }
  }
  t[x] = '\0';
}

 
void main()
{
  char usr[15], pss[15];
  int p, op;
start:
  clrscr();
  design();
  textcolor(YELLOW);
  gotoxy(21, 3);
  cprintf("WELCOME TO COLLEGE ADMISSION SYSTEM");
  gotoxy(21, 4);
  cprintf("-----------------------------------");
  textcolor(GREEN);
  gotoxy(23, 10);
  cprintf("Username : ");
  gotoxy(23, 13);
  cprintf("Password : ");
  textcolor(WHITE);
  gotoxy(34, 10);
  strcpy(gets(usr), usr);
  gotoxy(34, 13);
  p = 0;
  do
  {
    pss[p] = getch();
    if (pss[p] == 13)
    {
      break;
    }
    else if (pss[p] == 8 && p > 0)
    {
      cprintf("%c%c%c", 8, 32, 8);
    }
    else
    {
      cprintf("*");
      p++;
    }
  } while (pss[p] != 13);
  pss[p] = '\0';
  if (strcmp(usr, "admin") || strcmp(pss, "admin"))
  {
    clrscr();
    design();
    textcolor(RED + BLINK);
    gotoxy(16, 10);
    cprintf("Please Enter Valid Username And Password......");
    textcolor(WHITE);
    getch();
    goto start;
  }
  else
  {
    do
    {
      clrscr();
      design();
      main_box();
      textcolor(YELLOW);
      gotoxy(21, 5);
      cprintf("WELCOME TO COLLEGE ADMISSION SYSTEM");
      gotoxy(21, 6);
      cprintf("-----------------------------------");
      textcolor(CYAN);
      gotoxy(21, 12);
      cprintf("Please Enter Blinking Character : ");
      op = toupper(getch());
      switch (op)
      {
      case 'n':
      case 'N':
        course_entry();
        break;
      case 'c':
      case 'C':
        course();
        break;
      case 'a':
      case 'A':
        stud_menu();
        break;
      case 'f':
      case 'F':
        fees();
        break;
      case 'r':
      case 'R':
        rept_main();
        break;
      case 'h':
      case 'H':
        help();
        break;
      case 'e':
      case 'E':
        exit(0);
      default:
        clrscr();
        design();
        gotoxy(22, 10);
        textcolor(RED + BLINK);
        cprintf("Invalid Selection Try Again....");
        textcolor(WHITE);
        getch();
      }
    } while ((op != 'e') || (op != 'E'));
  }
}