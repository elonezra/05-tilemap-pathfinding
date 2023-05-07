# H.W 7

הפרויקט הבא הוא שיעורי הבית של שבוע 7, שאלה 2.

בחלק זה בחרתי את סעיף ב בו עלינו היה לתקן את המצב בו מפה שמוגרלת לא תגרום לשחקן להיות תקוע במפה בטווח של 100 משבצות.
תיקנתי את הפרויקט כך שכל עוד אין לשחקן אפשרות להגיע לאחד הגבולות המשחק יגריל מפה מחדש.

השינוייים שביצעתי הם בסקריפט שבניתי באופן ספציפי אותו ניתן לראות script>H.W

הסקריפט עובד באופן הבא 

```
    void Update()
    {
        if(!infunction) {
            infunction = true;
            run_generating();
                
        }
    }
```
פונקציית ה update תיקרא לפונקציית run_generating כל עוד הוא נקרא בפעם הראשונה.

```
    private void run_generating()
    {
        ....

        for(j = 2;j<98;j++)
        {
            target = new Vector3Int(2, j, 0);
            Debug.Log("e_debug target: " + target.ToString());
            List<Vector3Int> shortestPath = BFS.GetPath(graph, start, target, 1000);
            Debug.Log("e_debug count: " + shortestPath.Count.ToString());
            if (shortestPath.Count > 2)
            {
                return;//
            }
        }
        for (j = 2; j < 98; j++)
        {
            target = new Vector3Int(98, j, 0);
            Debug.Log("e_debug target: " + target.ToString());
            List<Vector3Int> shortestPath = BFS.GetPath(graph, start, target, 1000);
            Debug.Log("e_debug count: " + shortestPath.Count.ToString());
            if (shortestPath.Count > 2)
            {
                return;//
            }
        }
        
        ...

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
```
הפונקציית run_generating מפעילה 4 לולאות בהן נבדק באמצעות אלגוריתם הBFS האם יש מסלול מהשחקן לאחד הדפנות אם יש לפחות מסלול אחד, הפונקציה מפסיקה את פעולתה ונותנת לשחקן לשחק. אחרת תיטען הסצנה מחדש והסקריפט יתחיל מההתחלה.