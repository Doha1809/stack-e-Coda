namespace Stack_e_Coda

{
    public partial class Form1 : Form
    {
        Thread t1;
        Thread t2;
        //Thread t2 = new Thread();
        int[] T1 = new int[10];
        int[] T2 = new int[10];
        public Form1()
        {
            InitializeComponent();
            t1 = new Thread(Thread1);
            t2= new Thread(Thread2);
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void Thread1()
        {
            for (int i = 0; i < 10; i++)
            {
                label1.Invoke(new Action(() =>
                {
                    label1.Text = i.ToString();
                }));

                Thread.Sleep(1000);
                T1[i] = i;
            }
            Stack<int> stack1 = new Stack<int>();
            for (int i = 0; i < 10; i++)
            {
                stack1.Push(T1[i]);
            }
            for (int i = 0; i < 10; i++)
            {
                listBox1.Invoke(new Action(() =>
                {
                    listBox1.Items.Add(stack1.Pop().ToString());

                }));
                Thread.Sleep(1000);
            }
        }


        private void Thread2()
        {
            for (int i = 0; i < 10; i++)
            {
                label2.Invoke(new Action(() =>
                {
                    label2.Text = i.ToString();
                }));

                Thread.Sleep(1000);
                T2[i] = i;
            }
           Queue<int> queue = new Queue<int>();
            for (int i = 0; i < 10; i++)
            {
                queue.Enqueue(T2[i]);
            }
            for (int i = 0; i < 10; i++)
            {
                listBox1.Invoke(new Action(() =>
                {
                    listBox2.Items.Add(queue.Dequeue().ToString());

                }));
                Thread.Sleep(1000);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            t1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            t2.Start();
            
        }
    }
}