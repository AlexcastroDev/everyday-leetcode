# Challenge

https://leetcode.com/problems/image-smoother/

# First Try

```charp
public class ImageSmootherSolution {
    public int[][] ImageSmoother(int[][] img) {
        int m = img.Length;
        int n = img[0].Length;
        int[][] result = new int[m][];
        
        for (int i = 0; i < m; i++) {
            result[i] = new int[n];
            
            for (int j = 0; j < n; j++) {
                result[i][j] = SmoothPixel(img, i, j);
            }
        }
        
        return result;
    }

    private int SmoothPixel(int[][] img, int x, int y) {
        int m = img.Length;
        int n = img[0].Length;
        int sum = 0;
        int count = 0;
        
        for (int i = -1; i <= 1; i++) {
            for (int j = -1; j <= 1; j++) {
                int nx = x + i;
                int ny = y + j;
                
                if (IsValidCoordinate(nx, ny, m, n)) {
                    sum += img[nx][ny];
                    count++;
                }
            }
        }
        
        return sum / count;
    }

    private bool IsValidCoordinate(int x, int y, int m, int n) {
        return x >= 0 && x < m && y >= 0 && y < n;
    }
}
```


# Runtime
180ms

Beats 39.39% of users with C#

# Memory

66.9 MB

Beats 57.58% of users with C#



# Second Try

```charp
public class Solution {
    public int[][] ImageSmoother(int[][] img) {
        int m = img.Length;
        int n = img[0].Length;
        int[][] res = new int[m][];
        for (int i = 0; i < m; i++) {
            res[i] = new int[n];
            for (int j = 0; j < n; j++) {
                res[i][j] = Smoothen(img, i, j);
            }
        }
        return res;
    }

    private int Smoothen(int[][] img, int x, int y) {
        int m = img.Length;
        int n = img[0].Length;
        int sum = 0;
        int count = 0;
        for (int i = -1; i <= 1; i++) {
            for (int j = -1; j <= 1; j++) {
                int nx = x + i;
                int ny = y + j;
                if (nx < 0 || nx >= m || ny < 0 || ny >= n) continue;
                sum += img[nx][ny];
                count++;
            }
        }
        return sum / count;
    }
}
```


# Runtime
165ms

Beats 90.91% of users with C#

# Memory

66.73MB

Beats 63.64% of users with C#

