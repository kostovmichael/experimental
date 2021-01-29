package com.algexperimental;

/**
 * @author chad.zuniga
 *
 */
public class Percolation {
    private int size;
    private boolean[][] grid;
    /**
     *
     * @param n
     */
    public Percolation(int n) {
        this.size = n;
        grid = new boolean[n][n];
    }
    /**
     *
     * @param i
     * @param j
     */
    public void open(int i, int j) {
        if(!isOpen(i,j)) {
            this.grid[i][j] = true;
        }
    }
    /**
     *
     * @return
     */
    public boolean isOpen(int i, int j) {
        return this.grid[i][j];
    }
    /**
     *
     * @param i
     * @param j
     * @return
     */
    public boolean isFull(int i, int j) {
        return this.grid[i][j];
    }
    /**
     *
     * @return
     */
    public boolean percolates() {
        return false; //TODO
    }
    //Testing purposes
    public static void showGrid(Percolation p) {
        for(int i = 0; i <p.size; i++) {
            for(int j = 0; j < p.size; j++) {
                System.out.print("|");
                if(p.grid[i][j] == false) {
                    System.out.print("x");
                } else {
                    System.out.print("o");
                }
            }
            System.out.print("|\n");
        }
        System.out.println();
    }

    public static void main(String[] args) {
        Percolation p =  new Percolation(10);


    }
}
