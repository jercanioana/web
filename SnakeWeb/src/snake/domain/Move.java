package snake.domain;

public class Move {
    private int ID;
    private int userid;
    private String name;

    public Move(int ID,int userid, String name) {
        this.ID = ID;
        this.userid = userid;
        this.name = name;
    }

    public int getID() {
        return ID;
    }

    public void setID(int ID) {
        this.ID = ID;
    }
    public int getUserid() {
        return userid;
    }

    public void setUserid(int userid) {
        this.userid = userid;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }
}
