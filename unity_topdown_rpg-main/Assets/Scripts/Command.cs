using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command
{
    // "Trong lập trình hướng đối tượng, thì Command pattern là một pattern thiết kế hành vi trong đó một đối tượng được sử dụng để đóng gói tất cả các thông tin cần thiết để thực hiện một hành động hoặc kích hoạt một sự kiện ở thời gian sau đó.
    // Thông tin này bao gồm tên phương thức, đối tượng sở hữu phương thức và giá trị cho các tham số của phương thức."
    //How far should the box move when we press a button
    protected float moveDistance = 0.01f;

    //Move and maybe save command
    public abstract void Execute( Command command);

}

public class MoveLeft : Command
{
    //Called when we press a key
    public override void Execute(  Command command)
    {
        //Move the box

    }
    //Undo an old command
  
}

public class MoveRight : Command
{
    //Called when we press a key
    public override void Execute(  Command command)
    {
       

      

    }
    //Undo an old command
  

}

