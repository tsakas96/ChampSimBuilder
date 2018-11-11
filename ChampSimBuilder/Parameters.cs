using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampSimBuilder
{
    class Parameters
    {
        //CPU
        public int NUM_CPUS;

        public int CPU_FREQ;
        public int DRAM_IO_FREQ;

        public int ROB_SIZE;
        public int PAGE_SIZE;

        public int LQ_SIZE;
        public int SQ_SIZE;

        public int LQ_WIDTH;
        public int SQ_WIDTH;

        public int FETCH_WIDTH;
        public int DECODE_WIDTH;

        public int EXEC_WIDTH;
        public int RETIRE_WIDTH;

        public int SCHEDULER_SIZE;

        //TLB/CACHE
        public int BLOCK_SIZE;
        public int MAX_READ_PER_CYCLE;

        //INSTRUCTION TLB
        public int ITLB_SET;
        public int ITLB_WAY;
        public int ITLB_RQ_SIZE;
        public int ITLB_WQ_SIZE;
        public int ITLB_PQ_SIZE;
        public int ITLB_MSHR_SIZE;
        public int ITLB_LATENCY;

        //DATA TLB
        public int DTLB_SET;
        public int DTLB_WAY;
        public int DTLB_RQ_SIZE;
        public int DTLB_WQ_SIZE;
        public int DTLB_PQ_SIZE;
        public int DTLB_MSHR_SIZE;
        public int DTLB_LATENCY;

        //SECOND LEVEL TLB
        public int STLB_SET;
        public int STLB_WAY;
        public int STLB_RQ_SIZE;
        public int STLB_WQ_SIZE;
        public int STLB_PQ_SIZE;
        public int STLB_MSHR_SIZE;
        public int STLB_LATENCY;

        //L1 INSTRUCTION CACHE
        public int L1I_SET;
        public int L1I_WAY;
        public int L1I_RQ_SIZE;
        public int L1I_WQ_SIZE;
        public int L1I_PQ_SIZE;
        public int L1I_MSHR_SIZE;
        public int L1I_LATENCY;

        //L1 DATA CACHE
        public int L1D_SET;
        public int L1D_WAY;
        public int L1D_RQ_SIZE;
        public int L1D_WQ_SIZE;
        public int L1D_PQ_SIZE;
        public int L1D_MSHR_SIZE;
        public int L1D_LATENCY;

        //L2 CACHE
        public int L2C_SET;
        public int L2C_WAY;
        public int L2C_RQ_SIZE;
        public int L2C_WQ_SIZE;
        public int L2C_PQ_SIZE;
        public int L2C_MSHR_SIZE;
        public int L2C_LATENCY;

        //LAST LEVEL CACHE
        public int LLC_SET;
        public int LLC_WAY;
        public int LLC_RQ_SIZE;
        public int LLC_WQ_SIZE;
        public int LLC_PQ_SIZE;
        public int LLC_MSHR_SIZE;
        public int LLC_LATENCY;

        //DRAM
        public int DRAM_CHANNELS;
        public int DRAM_BANKS;

        public int DRAM_RANKS;
        public int DRAM_ROWS;

        public int DRAM_COLUMNS;
        public int DRAM_CHANNEL_WIDTH;

        public int DRAM_RQ_SIZE;
        public int DRAM_WQ_SIZE;

        public int tRP_DRAM_CYCLE;
        public int tCAS_DRAM_CYCLE;
        public int tRCD_DRAM_CYCLE;
    }
}