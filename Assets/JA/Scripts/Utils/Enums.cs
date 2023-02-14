public class Enums
{
    public enum CustomerState
    {
        VisitGeneral, // 일반적인 방문 인사
        VisitComment, // 캐릭터 방문 인사
        RefusalComment, // 캐릭터 거절 대사
        RequestComment, // 향 요청 대사
        ResultCommentGood, // 결과 대사/
        ResultCommentNormal, // 결과 대사
        ResultCommentBad, // 결과 대사
        NoExist, // 없다
        NoFlavor // 향료가 없다.
    }
    
    public enum CustomerFace
    {
        sad,
        happy,
    }
    
    public enum MoveButton
    {
        RootOfReadButton,
        AlleyButton,
        TreeButton,
        LorenaButton,
        AronButton
    }
}
