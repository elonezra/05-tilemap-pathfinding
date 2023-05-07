using System;

class Graph
{
    private int V; // Number of vertices
    private int[,] edges; // Adjacency matrix

    public Graph(int V)
    {
        this.V = V;
        this.edges = new int[V, V];
    }

    public void AddEdge(int u, int v, int weight)
    {
        edges[u, v] = weight;
    }

    public int[] LongestPaths(int source)
    {
        // Initialize distances to negative infinity
        int[] dist = new int[V];
        for (int i = 0; i < V; i++)
            dist[i] = int.MinValue;
        dist[source] = 0;

        // Relax edges repeatedly
        for (int k = 0; k < V - 1; k++)
        {
            for (int u = 0; u < V; u++)
            {
                for (int v = 0; v < V; v++)
                {
                    if (edges[u, v] != 0 && dist[u] != int.MinValue && dist[u] + edges[u, v] > dist[v])
                        dist[v] = dist[u] + edges[u, v];
                }
            }
        }

        // Check for negative cycles
        for (int u = 0; u < V; u++)
        {
            for (int v = 0; v < V; v++)
            {
                if (edges[u, v] != 0 && dist[u] != int.MinValue && dist[u] + edges[u, v] > dist[v])
                    throw new Exception("Graph contains a negative cycle!");
            }
        }

        return dist;
    }
}

