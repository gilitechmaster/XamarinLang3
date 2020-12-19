using lang3.Model;
using System;
using System.Collections.Generic;
using System.IO;
using Xamarin.Forms;
namespace lang3
{
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
        }
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;
            if (string.IsNullOrWhiteSpace(note.Filename)) //문자열이 널인지 공백인지 확인한다.
            {
                var filename = Path.Combine(App.FolderPath, $"{Path.GetRandomFileName()}.notes.txt");
                File.WriteAllText(filename, note.Text);
            }
            else
            {
                File.WriteAllText(note.Filename, note.Text);
            }
            await Navigation.PopAsync();
        }//저장버튼 누르면
        async void OnCalc1ButtonClicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;
            if (string.IsNullOrWhiteSpace(note.Filename))
            {
                var filename = Path.Combine(App.FolderPath, $"{Path.GetRandomFileName()}.notes.txt");
                File.WriteAllText(filename, note.Text);
            }
            else
            {
                var filename = Path.Combine(App.FolderPath, $"{Path.GetRandomFileName()}.notes.txt");
                File.WriteAllText(note.Filename, note.Text);
                StreamWriter sw = new StreamWriter(filename, true);
                string[] arr = note.Text.Split(new string[]{
                "",
                        }, StringSplitOptions.None);
                foreach (string B in arr)
                {
                    if (B.Contains("\n")  // replace로 2차처리
                        )
                        sw.WriteLine("{0}", B
                          .Replace("\n", "")
                          );
                }
                sw.Close();
            }
            await Navigation.PopAsync();
        }
        //조합버튼 누르면
        //웹에서 문서를 수집하면, 어수선한 글이 많아서
        //조합을 먼저한 이후에 분해한다.
        async void OnCalc2ButtonClicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;
            if (string.IsNullOrWhiteSpace(note.Filename))
            {
                var filename = Path.Combine(App.FolderPath, $"{Path.GetRandomFileName()}.notes.txt");
                File.WriteAllText(filename, note.Text);
            }
            else
            {
                var filename = Path.Combine(App.FolderPath, $"{Path.GetRandomFileName()}.notes.txt");
                File.WriteAllText(note.Filename, note.Text);
                StreamWriter sw = new StreamWriter(filename, true);

                string[] arr = note.Text.Split(new string[] {


                    ", ",
                    ",",
                    ". ",
                    ".",
                    " "


                }, StringSplitOptions.None);

                int Key = 1;

                sw.WriteLine("어휘갯수 : {0}", arr.Length);


                foreach (string B in arr)
                {

                    sw.WriteLine("\n" + Key++ + ") " + B);


                    // 이것을 사용하면 원본 문서가 출력txt에 출력된다.

                    //교착굴절을 하나의 Writeline에 넣는다.
                    //교착굴절의 표기는 Repalce에 삽입하므로
                    //코드내부에서는 자음 순서로 정렬한다.

                    //無=기본
                    //이거 안되네....

                    //if (B.EndsWith("") == true)
                    //sw.WriteLine("{0}", B
                    //.Replace("", "(기본)")
                    //);


                    //ㄱ

                    if (B.EndsWith("과") == true)
                        sw.WriteLine("{0}", B
                            .Replace("과", "과(교착)")
                            .Replace("과", "(기본)")
                            );
                    if (B.EndsWith("가") == true)
                        sw.WriteLine("{0}", B
                            .Replace("되는가", "는가(교착)")
                            .Replace("는가", "가(교착)")

                            .Replace("가", "(기본)")
                            );
                    if (B.EndsWith("게") == true)
                        sw.WriteLine("{0}", B

                            .Replace("나게", "게(교착)")
                            .Replace("에게", "게(교착)")
                            .Replace("하게", "게(교착)")

                            .Replace("게", "게(교착)")
                            .Replace("게", "(기본)")
                            );
                    if (B.EndsWith("겐") == true)
                        sw.WriteLine("{0}", B
                            .Replace("에겐", "겐(교착)")
                            .Replace("겐", "게ㄴ(굴절)")
                            );
                    if (B.EndsWith("고") == true)
                        sw.WriteLine("{0}", B

                         .Replace("주고", "고(교착)")

                        .Replace("었다고", "다고(교착)")
                        .Replace("다고", "고(교착)")

                        .Replace("하고", "고(교착)")
                        .Replace("라고", "고(교착)")


                        .Replace("고", "(기본)")
                        );
                    if (B.EndsWith("기") == true)
                        sw.WriteLine("{0}", B
                            .Replace("이기", "기(교착)")
                            .Replace("하기", "기(교착)")
                            .Replace("기", "기(교착)")
                            .Replace("기", "(기본)")
                            );





                    //ㄴ

                    if (B.EndsWith("는") == true)
                        sw.WriteLine("{0}", B
                            .Replace("까지는", "지는(교착)")
                            .Replace("지는", "는(교착)")

                            //.Replace("되는", "는(교착)")
                            .Replace("로는", "는(교착)")

                            .Replace("에서는", "에는(교착)")
                            .Replace("에는", "는(교착)")

                            .Replace("한다는", "한다는(교착)")
                            .Replace("한다", "하ㄴ다는(굴절)")
                            .Replace("하ㄴ다는", "하다는(교착)")
                            .Replace("하다는", "다는(교착)")
                            .Replace("다는", "는(교착)")

                            .Replace("는", "(기본)")
                            );
                    if (B.EndsWith("나") == true)
                        sw.WriteLine("{0}", B
                            .Replace("었으나", "으나(교착)")
                            .Replace("으나", "나(교착)")

                            .Replace("나", "나(교착)")
                            .Replace("나", "(기본)")
                            );
                    if (B.EndsWith("니") == true)
                        sw.WriteLine("{0}", B


                            .Replace("하니", "니(교착)")

                            .Replace("하였니", "하여ㅆ니(굴절)")
                            .Replace("하여ㅆ니", "여ㅆ니(교착)")

                            .Replace("였니", "여ㅆ니(굴절)")

                            .Replace("여ㅆ니", "ㅆ니(교착)")
                            .Replace("ㅆ니", "니(교착)")

                            .Replace("니", "(기본)")

                            );
                    if (B.EndsWith("눌") == true)
                        sw.WriteLine("{0}", B
                            .Replace("눌", "누ㄹ(굴절)")
                            );


                    //ㄷ


                    if (B.EndsWith("다") == true)
                        sw.WriteLine("{0}", B



                        .Replace("꿨다", "꿔ㅆ다(굴절)")
                        .Replace("꿔ㅆ다", "ㅆ다(교착)")
                        .Replace("났다", "나ㅆ다(교착)")
                        .Replace("나ㅆ다", "ㅆ다(교착)")
                        .Replace("였다", "여ㅆ다(굴절)")
                        .Replace("여ㅆ다", "ㅆ다(교착)")
                        .Replace("했다", "해ㅆ다(굴절)")
                        .Replace("해ㅆ다", "ㅆ다(굴절)")
                        .Replace("ㅆ다", "다(교착)")

                        .Replace("간다", "가ㄴ다(굴절)")
                        .Replace("가ㄴ다", "ㄴ다(교착)")
                        .Replace("된다", "되ㄴ다(굴절)")
                        .Replace("되ㄴ다", "ㄴ다(교착)")
                        .Replace("어진다", "어지ㄴ다(굴절)")
                        .Replace("어지ㄴ다", "지ㄴ다(교착)")
                        .Replace("지ㄴ다", "ㄴ다(교착)")
                        .Replace("한다", "하ㄴ다(굴절)")
                        .Replace("하ㄴ다", "ㄴ다(교착)")
                        .Replace("ㄴ다", "다(교착)")


                        .Replace("드립니다", "드리ㅂ니다(굴절)")
                        .Replace("드리ㅂ니다", "리ㅂ니다(교착)")
                        .Replace("리ㅂ니다", "ㅂ니다(교착)")
                        .Replace("됩니다", "되ㅂ니다(굴절)")
                        .Replace("답니다", "다ㅂ니다(굴절)")
                        .Replace("다ㅂ니다", "ㅂ니다(교착)")
                        .Replace("시킵니다", "시키ㅂ니다(굴절)")
                        .Replace("시키ㅂ니다", "키ㅂ니다(교착)")
                        .Replace("키ㅂ니다", "ㅂ니다(교착)")
                        .Replace("습니다", "스ㅂ니다(굴절)")
                        .Replace("스ㅂ니다", "ㅂ니다(교착)")
                        .Replace("합니다", "하ㅂ니다(굴절)")
                        .Replace("하ㅂ니다", "ㅂ니다(교착)")
                        .Replace("ㅂ니다", "니다(교착)")
                        .Replace("니다", "다(교착)")



                        .Replace("하다", "다(교착)")


                        .Replace("다", "(기본)")
                        );

                    if (B.EndsWith("도") == true)
                        sw.WriteLine("{0}", B
                        .Replace("하기도", "기도(교착)")
                        .Replace("기도", "도(교착)")
                        .Replace("에도", "도(교착)")

                        .Replace("도", "(기본)")
                        );

                    if (B.EndsWith("든") == true)
                        sw.WriteLine("{0}", B
                        .Replace("든", "드ㄴ(굴절)")
                        );
                    if (B.EndsWith("들") == true)
                        sw.WriteLine("{0}", B
                        .Replace("들", "드ㄹ(굴절)")
                        );

                    if (B.EndsWith("된") == true)
                        sw.WriteLine("{0}", B
                        .Replace("된", "되ㄴ(굴절)")
                        //.Replace("되ㄴ", "되다(교착)")
                        );
                    if (B.EndsWith("될") == true)
                        sw.WriteLine("{0}", B
                        .Replace("될", "되ㄹ(굴절)")
                        );




                    //ㄹ

                    if (B.EndsWith("라") == true)
                        sw.WriteLine("{0}", B
                        .Replace("라", "라(교착)")
                        .Replace("라", "(기본)")
                        );
                    if (B.EndsWith("려") == true)
                        sw.WriteLine("{0}", B
                        .Replace("려", "려(교착)")
                        .Replace("려", "(기본)")
                        );
                    if (B.EndsWith("란") == true)
                        sw.WriteLine("{0}", B
                        .Replace("이란", "이라ㄴ(굴절)")
                        //.Replace("이라ㄴ", "라ㄴ(교착)")
                        //.Replace("라ㄴ", "다(교착)")
                        );
                    if (B.EndsWith("로") == true)
                        sw.WriteLine("{0}", B

                            .Replace("적으로", "으로로(교착)")
                            .Replace("으로", "로(교착)")
                            .Replace("로", "로(교착)")
                            .Replace("로", "(기본)")
                            );

                    if (B.EndsWith("록") == true)
                        sw.WriteLine("{0}", B
                            .Replace("살펴보도록", "살펴보ㄷㅗ록(굴절)")
                            //.Replace("보ㄷㅗ록", "보ㄷ(굴절)")
                            //.Replace("보ㄷ", "보다(교착)")
                            );
                    if (B.EndsWith("른") == true)
                        sw.WriteLine("{0}", B
                            .Replace("른", "르ㄴ(굴절)")
                            );
                    if (B.EndsWith("를") == true)
                        sw.WriteLine("{0}", B
                            .Replace("를", "를(교착)")
                            .Replace("를", "(기본)")
                            );


                    //ㅁ


                    if (B.EndsWith("며") == true)
                        sw.WriteLine("{0}", B
                            .Replace("으며", "며(교착)")
                            .Replace("리며", "며(교착)")
                            .Replace("며", "며(교착)")
                            .Replace("며", "(기본)")
                            );

                    if (B.EndsWith("면") == true)
                        sw.WriteLine("{0}", B

                            .Replace("더라면", "라면(교착)")
                            .Replace("라면", "면(교착)")

                            .Replace("되면", "면(교착)")
                            .Replace("으면", "면(교착)")

                            .Replace("리려면", "려면(교착)")
                            .Replace("려면", "면(교착)")

                            .Replace("면", "면(교착)")
                            .Replace("면", "(기본)")
                            );

                    //if (B.EndsWith("만") == true)
                    //sw.WriteLine("{0}", B
                    //.Replace("르지만", "르지마ㄴ(굴절)")
                    //.Replace("지마ㄴ", "ㅈ(교착)")
                    //.Replace("ㅈ", "다(교착)")
                    //);



                    //ㅂ


                    //ㅅ


                    if (B.EndsWith("서") == true)
                        sw.WriteLine("{0}", B

                            .Replace("에서", "서(교착)")
                            .Replace("어서", "서(교착)")
                            .Replace("해서", "서(교착)")

                            .Replace("서", "서(교착)")
                            .Replace("서", "(기본)")
                            );
                    if (B.EndsWith("선") == true)
                        sw.WriteLine("{0}", B
                        //.Replace("넘어선", "넘어서ㄴ(굴절)")
                        .Replace("어선", "어서ㄴ(굴절)")
                        //.Replace("어서ㄴ", "서ㄴ(교착)")
                        //.Replace("서ㄴ", "선(교착)")
                        //.Replace("서다", "다(교착)")
                        );



                    //ㅇ

                    if (B.EndsWith("어") == true)
                        sw.WriteLine("{0}", B
                            .Replace("되어", "어(교착)")
                            .Replace("어", "어(교착)")
                            .Replace("어", "(기본)")
                            );
                    if (B.EndsWith("에") == true)
                        sw.WriteLine("{0}", B
                            .Replace("에", "에(교착)")
                            .Replace("에", "(기본)")
                            );
                    if (B.EndsWith("여") == true)
                        sw.WriteLine("{0}", B
                        .Replace("하여", "여(교착)")
                        //.Replace("하다", "다(교착)")
                        .Replace("여", "(기본)")
                        );
                    if (B.EndsWith("요") == true)
                        sw.WriteLine("{0}", B

                            .Replace("해주세요", "주세요(교착)")
                            .Replace("주세요", "세요(교착)")
                            .Replace("세요", "요(교착)")

                            .Replace("요", "(기본)")

                            );
                    if (B.EndsWith("운") == true)
                        sw.WriteLine("{0}", B
                            .Replace("운", "우ㄴ(굴절)")
                            );
                    if (B.EndsWith("의") == true)
                        sw.WriteLine("{0}", B
                            .Replace("의", "의(교착)")
                            .Replace("의", "(기본)")
                            );
                    if (B.EndsWith("은") == true)
                        sw.WriteLine("{0}", B
                            .Replace("은", "은(교착)")
                            .Replace("은", "(기본)")
                            );
                    if (B.EndsWith("을") == true)
                        sw.WriteLine("{0}", B

                            .Replace("했을", "을(교착)")
                            .Replace("을", "을(교착)")

                            .Replace("을", "(기본)")
                            );
                    if (B.EndsWith("이") == true)
                        sw.WriteLine("{0}", B
                            .Replace("임이", "이(교착)")
                            .Replace("이", "이(교착)")
                            .Replace("이", "(기본)")
                            );
                    if (B.EndsWith("인") == true)
                        sw.WriteLine("{0}", B
                        .Replace("인", "이ㄴ(굴절)")
                        //.Replace("이ㄴ", "이다(교착)")
                        );
                    if (B.EndsWith("일") == true)
                        sw.WriteLine("{0}", B
                        .Replace("일", "이ㄹ(굴절)")
                        );
                    if (B.EndsWith("와") == true)
                        sw.WriteLine("{0}", B
                            .Replace("와", "와(교착)")
                            .Replace("와", "(기본)")
                            );



                    //if (B.EndsWith("이라") == true)
                    //sw.WriteLine("{0}", B
                    //.Replace("이라", "이라(이중교착)")
                    //);



                    //ㅈ
                    if (B.EndsWith("적") == true)
                        sw.WriteLine("{0}", B
                        .Replace("적", "적(교착))")
                        .Replace("적", "(기본))")
                        );
                    if (B.EndsWith("지") == true)
                        sw.WriteLine("{0}", B

                        .Replace("까지", "지(교착)")
                        //.Replace("되지", "지(교착)")
                        .Replace("이지", "지(교착)")

                        .Replace("하는지", "는지(교착)")
                        .Replace("는지", "지(교착)")

                        .Replace("지", "(기본)")

                        );
                    if (B.EndsWith("진") == true)
                        sw.WriteLine("{0}", B
                        .Replace("진", "지ㄴ(굴절)")
                        //.Replace("지ㄴ", "진(교착)")
                        );

                    if (B.EndsWith("져") == true)
                        sw.WriteLine("{0}", B
                        //.Replace("어져", "져(교착)")
                        //.Replace("져", "지다(굴절)")
                        );
                    if (B.EndsWith("죠") == true)
                        sw.WriteLine("{0}", B
                        .Replace("었죠", "었ㅈ요(굴절)")
                        .Replace("었ㅈ요", "ㅈ요(교착)")
                        .Replace("ㅈ요", "죠(굴절)")
                        .Replace("죠", "(기본)")
                        );


                    //ㅊ
                    if (B.EndsWith("칠") == true)
                        sw.WriteLine("{0}", B
                        //.Replace("마주칠", "마주치ㄹ(굴절)")
                        .Replace("주칠", "주치ㄹ(굴절)")
                        //.Replace("치ㄹ", "치(교착)")
                        //.Replace("치", "(기본)")
                        );


                    //ㅌ


                    //ㅍ



                    //ㅎ

                    if (B.EndsWith("한") == true)
                        sw.WriteLine("{0}", B
                        .Replace("한", "하ㄴ(굴절)")
                        //.Replace("하ㄴ", "하다(교착)")
                        //.Replace("하다", "(기본)")
                        );
                    if (B.EndsWith("할") == true)
                        sw.WriteLine("{0}", B
                        .Replace("할", "하ㄹ(굴절)")
                        //.Replace("하ㄹ", "하다(교착)")
                        //.Replace("하다", "(기본)")
                        );

                    if (B.EndsWith("해") == true)
                        sw.WriteLine("{0}", B
                        .Replace("해", "(교착)")
                        );

                    if (B.EndsWith("히") == true)
                        sw.WriteLine("{0}", B
                        .Replace("히", "ㅎㅣ(굴절)")
                        .Replace("ㅎㅣ", "ㅎ(교착)")
                        );






                } // split로 1차처리
                sw.Close();
            }
            await Navigation.PopAsync();
        }//분해버튼 누르면

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;
            if (File.Exists(note.Filename))
            {
                File.Delete(note.Filename);
            }
            await Navigation.PopAsync();
        }//삭제버튼 누르면
    }
}